using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TES.Integration.HTTPClient
{
    public class BaseClient
    {
        #region vars
        private HttpClient client;
        #endregion
        #region properties
        public string endPoint { get; set; }
        public string authName { get; set; }
        public string authToken { get; set; }
        public string mediaType { get; set; }
        public string API { get; set; }
        public string responseString { get; set; }
        public string errorText { get; set; }
        #endregion
        #region constructors
        public BaseClient(string authName, string authToken, string mediaType, string API)
        {
            this.authName = authName;
            this.authToken = authToken;
            this.mediaType = mediaType;
            this.API = API;
            InitialiseClient();
        }
        public BaseClient(string endPoint, string authName, string authToken, string mediaType, string API)

        {
            this.endPoint = endPoint;
            this.authName = authName;
            this.authToken = authToken;
            this.mediaType = mediaType;
            this.API = API;
            InitialiseClient();
        }
        #endregion
        #region methods
        private void InitialiseClient()

        {
            this.client = new HttpClient();
            switch (this.API)
            {
                case "247-IKD-Initial":
                    break;
                case "247-IKD":
                    this.client.DefaultRequestHeaders.Clear();
                    this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
                    this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authToken);
                    break;
            }
        }
        public void AddHeader(string name, string value)
        {
            this.client.DefaultRequestHeaders.Add(name, value);
        }
        public bool GetRequest(string url)
        {
            try
            {
                if (this.endPoint != null)
                {
                    url = this.endPoint + url;
                }
                var response = this.client.GetAsync(url).Result;
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                errorText = e.Message + ": " + e.InnerException;
                return false;
            }
            return true;
        }
        public bool PutRequest(string url, object payload)
        {
            try
            {
                if (this.endPoint != null)
                {
                    url = this.endPoint + url;
                }
                var stringPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, this.mediaType);
                var response = this.client.PutAsync(url, httpContent).Result;
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                errorText = e.Message + ": " + e.InnerException;
                return false;
            }
            return true;
        }
        public bool PostRequest(string url, object payload)
        {
            try
            {
                if (this.endPoint != null)
                {
                    url = this.endPoint + url;
                }
                var stringPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, this.mediaType);
                var response = this.client.PostAsync(url, httpContent).Result;
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                errorText = e.Message + ": " + e.InnerException;
                return false;
            }
            return true;
        }
        public bool PostRequest(string url, string payload)
        {
            try
            {
                if (this.endPoint != null)
                {
                    url = this.endPoint + url;
                }
                var httpContent = new StringContent(payload, Encoding.UTF8, this.mediaType);
                var response = this.client.PostAsync(url, httpContent).Result;
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                errorText = e.Message + ": " + e.InnerException;
                return false;
            }
            return true;
        }
        #endregion
    }
}
