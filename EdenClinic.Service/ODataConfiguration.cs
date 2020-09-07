/*
*
* Generated At 9/7/2020 2:41:29 PM
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Service
{
    public class ODataConfiguration
    {
       public static string ServerUrl => WebServiceUrl.Replace("/api", "");
        public string ReportsFormUrl { get; set; }
        public static string WebServiceUrl { get; set; }
		public static string UploadsBaseUrl => $"{WebServiceUrl.Replace("/api", "")}Uploads/";
        public string BaseUrl
        {
            get
            {
               return WebServiceUrl;
            }

        }

        public string AccessToken { get; set; }
        public Action<string, object[]> OnTrance { get; set; }
        public Action<ExceptionObject> ExceptionTrace { get; set; }
        public HttpClient Http
        {
            get
            {
                HttpClient http = new HttpClient();
                if (!String.IsNullOrEmpty(AccessToken))
                {
                    http.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", AccessToken);
                }
                return http;
            }
        }
    }
}
