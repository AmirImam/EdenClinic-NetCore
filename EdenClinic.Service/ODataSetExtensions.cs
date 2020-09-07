using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Service
{
    public static class ODataSetExtensions
    {
        public static async Task<ResponseResult<Person>> Login(this ODataSet<Person> context, string email, string password) //where T : UserBase
        {
            ResponseResult<Person> result = new ResponseResult<Person>();
            UserLoginModel model = new UserLoginModel() { Email = email, Password = password };
            HttpClient http = new HttpClient();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync($"{ODataConfiguration.WebServiceUrl}{typeof(Person).Name}/Login", content);
            if (response.IsSuccessStatusCode == false)
            {
                result.Message = await response.Content.ReadAsStringAsync();
                result.Success = false;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Person resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(responseContent);
                result.Model = resultModel;
                result.Success = true;
            }
            return result;
        }
        public static async Task<ResponseResult<Person>> CreateFirstAdmin(this ODataSet<Person> context)
        {
            var response = await context.Configuration.Http
                .PostAsync($"{ODataConfiguration.WebServiceUrl}Person/CreateFirstAdmin",null);
            var content = await response.Content.ReadAsStringAsync();
            if (String.IsNullOrEmpty(content))
            {
                return new ResponseResult<Person>()
                {
                    Success = false
                };
            }
            else
            {
                return new ResponseResult<Person>()
                {
                    Success = true,
                    Model = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(content)
                };
            }
        }
    }
}
