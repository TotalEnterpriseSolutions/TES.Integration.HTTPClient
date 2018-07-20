using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Testing_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = "{\"message\":\"%fieldName is a required field.\",\"parameters\":{\"fieldName\":\"product\",\"fieldValue\":\"123\"}}";
            JObject jo = JObject.Parse(jsonstring);
            JToken jt;
            bool result = jo.TryGetValue("message",out jt);
            
            Console.WriteLine(jt.ToString());
            Console.ReadLine();
        }
    }
}
