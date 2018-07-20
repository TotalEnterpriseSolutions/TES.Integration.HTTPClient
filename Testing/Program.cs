using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Integration.HTTPClient;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = "{\"username\":\"Apiuser\",\"password\":\"apiuser*987\"}";
            string itemjsonstring = "{\"Items\":[{\"set\":\"4\",\"sku\":\"100024\",\"classification\":\"4\",\"section\":\"\",\"subsection\":\"\",\"name\":\"Baby sun lotion\",\"description\":\"\",\"short_description\":\"\",\"weight\":\"0\",\"status\":\"0\",\"visibility\":\"Catalog and Search\",\"website_ids\":\"1\",\"price\":\"33.00\",\"tax_class_id\":\"2\",\"meta_title\":\"Baby sun lotion\",\"meta_keyword\":\"Baby sun lotion\",\"meta_description\":\"Baby sun lotion\",\"brand\":\"\",\"distrib_rest\":\"\",\"color\":\"\",\"size\":\"\",\"expiry_date\":\"\",\"pack_qty\":\"0\",\"fundraising\":\"6370743\",\"rrp\":\"566.00\",\"web_info\":\"\",\"delivery_options\":\"5\",\"qty\":\"0\",\"is_in_stock\":\"0\",\"estimate_is_in_stock)\":\"0\",\"min_sale_qty\":\"1\",\"max_sale_qty\":\"1\"}]}";
            string baseendpoint = @"http://ec2-34-244-205-131.eu-west-1.compute.amazonaws.com";
            string apiendpoint = @"/inkindDirect/index.php/rest/V1/integration/admin/token";
            string itemapiendpoint = @"/inkindDirect/index.php/rest/V1/products";
            string apikey = "dtuvr0hqek74lvawqw0dfsnk69rrvwy9";

            //BaseClient c = new BaseClient(baseendpoint, "", "", "application/json", "247-IKD-INITIAL");
            BaseClient c = new BaseClient(baseendpoint, "Apiuser", apikey, "application/json", "247-IKD");
            //if (c.PostRequest(apiendpoint, jsonstring))
            if (c.PostRequest(itemapiendpoint,itemjsonstring))
            {
                Console.WriteLine("Success:");
                string s = c.responseString;
                Console.WriteLine(c.responseString);
            }
            else
            {
                Console.WriteLine("Failed:");
                Console.WriteLine(c.errorText);
            }

            Console.ReadLine();
        }
    }
}
