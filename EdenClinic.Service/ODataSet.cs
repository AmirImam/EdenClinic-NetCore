/*
*
* Generated At 9/7/2020 9:10:37 AM
*
*/
using EdenClinic.Models;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Service
{
    public class ODataSet<T> where T : class
    {
        IBoundClient<T> bounder;
        public ODataConfiguration Configuration;
        ODataClientSettings settings;
        private struct AggregationResults
        {
            public string Value { get; set; }
        }
        public ODataSet(ODataConfiguration config)
        {
            this.Configuration = config;
            settings = new ODataClientSettings();
            settings.PreferredUpdateMethod = ODataUpdateMethod.Put;
            settings.IgnoreUnmappedProperties = true;
            settings.BaseUri = new Uri(config.BaseUrl);

            settings.BeforeRequest = (request) =>
            {
                //if (config.AccessToken != null)
                //{
                //    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", config.AccessToken);
                //}
            };
            if (config.OnTrance != null)
            {
                settings.OnTrace = config.OnTrance;
            }
            

            bounder = new ODataClient(settings).For<T>();
        }
        
        private void Dispose()
        {
            bounder = new ODataClient(settings).For<T>();
        }

        public ODataSet<T> Select(Expression<Func<T, object>> expression)
        {
            bounder = bounder.Select(expression);
            return this;
        }
        public ODataSet<T> Where(Expression<Func<T, bool>> expression)
        {
            bounder = bounder.Filter(expression);
            return this;
        }
        public ODataSet<T> Where(string filter)
        {
            bounder = bounder.Filter(filter);
            return this;
        }
        public ODataSet<T> OrderBy(Expression<Func<T, object>> expression)
        {
            bounder = bounder.OrderBy(expression);
            return this;
        }
        public ODataSet<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            bounder = bounder.OrderByDescending(expression);
            return this;
        }
        public ODataSet<T> ThenBy(Expression<Func<T, object>> expression)
        {
            bounder = bounder.ThenBy(expression);
            return this;
        }
        public ODataSet<T> ThenByDescending(Expression<Func<T, object>> expression)
        {
            bounder = bounder.ThenByDescending(expression);
            return this;
        }
        public ODataSet<T> Include(Expression<Func<T, object>> expression)
        {
            bounder = bounder.Expand(expression);
            return this;
        }

        public ODataSet<T> Take(long number)
        {
            bounder = bounder.Top(number);
            return this;
        }
        public ODataSet<T> Skip(long number)
        {
            bounder = bounder.Skip(number);
            return this;
        }

        public async Task<IEnumerable<T>> ResultAsync()
        {
            try
            {
                var command = await bounder.GetCommandTextAsync();
                var result = await bounder.FindEntriesAsync();
                Dispose();
                return result;
            }
            catch (Exception ex)
            {
                //throw new Exception("ClientService Exception", ex);
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<IEnumerable<T>> ResultAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                bounder = bounder.Filter(expression);
                var result = await bounder.FindEntriesAsync();
                Dispose();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<T> FirstAsync()
        {
            try
            {
                string command = await bounder.GetCommandTextAsync();
                var result = await bounder.FindEntryAsync();
                Dispose();
                return result;
            }
            catch (Exception ex)
            {
                //configuration.ExceptionTrace?.Invoke(new ExceptionObject() { Exception = ex, ODataCommand = await bounder.GetCommandTextAsync() });
                return null;
            }
        }
        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                bounder = bounder.Filter(expression);
                string command = await bounder.GetCommandTextAsync();
                var result = await bounder.FindEntryAsync();
                Dispose();
                return result;
            }
            catch (Exception ex)
            {
                //configuration.ExceptionTrace?.Invoke(new ExceptionObject() { Exception = ex, ODataCommand = await bounder.GetCommandTextAsync() });
                return null;
            }
        }


        public async Task<int> Count()
        {
            //bounder = bounder.Count();
            var count = await bounder.Count().FindScalarAsync<int>();
            Dispose();
            return count;
        }
        public async Task<int> Count(Expression<Func<T, bool>> expression)
        {
            //bounder = bounder.Count();
            bounder = bounder.Filter(expression);
            var count = await bounder.Count().FindScalarAsync<int>();
            Dispose();
            return count;
        }

        public async Task<TResult> Max<TResult>()
        {
            var result = await GetAverage<TResult>("MAX");
            return result;
        }
        public async Task<TResult> Sum<TResult>()
        {
            var result =await GetAverage<TResult>("SUM");
            return result;
        }
        private async Task<TResult> GetAverage<TResult>(string caller)
        {
            //"/Average?caller=Sum&$select=Price&$filter=Price gt 10"
            HttpClient client = new HttpClient();
            string command = await bounder.GetCommandTextAsync();
            string tableName = $"{typeof(T).Name}?";
            string url = $"{settings.BaseUri.ToString()}{typeof(T).Name}/Average?caller={caller}&{command.Replace(tableName, "")}";
            HttpResponseMessage response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode == false)
            {
                return default(TResult);
            }
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<GenericModel> model = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<GenericModel>>(content);
            if(model.Count() == 0)
            {
                return default(TResult);
            }
            string row = model.ElementAt(0).Value;
            var result = (TResult)Convert.ChangeType(row, typeof(TResult));
            
            return result;
        }



        public async Task<ResponseResult<T>> InsertEntityAsync(T entity)
        {
            ResponseResult<T> result = new ResponseResult<T>();
            try
            {
                var response = await bounder.Set(entity).InsertEntryAsync();
                if (response != null)
                {
                    result.Model = response;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error";
                }
            }
            catch (WebRequestException ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            finally
            {
                Dispose();
            }

            return result;
        }
        public async Task<ResponseResult<T>> InsertRangeAsync(IEnumerable<T> range)
        {
            ResponseResult<T> result = new ResponseResult<T>();
            try
            {
                HttpClient client = new HttpClient();

                string rangeJson = Newtonsoft.Json.JsonConvert.SerializeObject(range);
                StringContent content = new StringContent(rangeJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{settings.BaseUri.ToString()}{typeof(T).Name}/PostRange", content);// await bounder.Set(range).InsertEntryAsync();
                result.Success = response.IsSuccessStatusCode; ;
                if (response.IsSuccessStatusCode == false)
                {
                    //result.Model = null;
                    result.Message = await content.ReadAsStringAsync();
                }
               
            }
            catch (WebRequestException ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            finally
            {
                Dispose();
            }

            return result;
        }
        public async Task<ResponseResult<T>> UpdateEntityAsync(Guid id, T entity)
        {
            ResponseResult<T> result = new ResponseResult<T>();
            try
            {
                var response = await bounder.Set(entity)
                    .Key(id)
                    .UpdateEntryAsync();
                if (response != null)
                {
                    result.Model = response;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error";
                }
            }
            catch (WebRequestException ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            finally
            {
                Dispose();
            }

            return result;
        }
        public async Task<ResponseResult<T>> DeleteEntityAsync(Guid id)
        {
            ResponseResult<T> result = new ResponseResult<T>();
            try
            {
                await bounder
                    .Key(id)
                    .DeleteEntryAsync();
                result.Success = true;
            }
            catch (WebRequestException ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            finally
            {
                Dispose();
            }

            return result;
        }
        public async Task<ResponseResult<T>> DeleteRangeAsync(IEnumerable<T> range)
        {
            ResponseResult<T> result = new ResponseResult<T>();
            try
            {
                HttpClient client = new HttpClient();

                string rangeJson = Newtonsoft.Json.JsonConvert.SerializeObject(range);
                StringContent content = new StringContent(rangeJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{settings.BaseUri.ToString()}{typeof(T).Name}/DeleteRange", content);// await bounder.Set(range).InsertEntryAsync();
                result.Success = response.IsSuccessStatusCode; ;
                if (response.IsSuccessStatusCode == false)
                {
                    //result.Model = null;
                    result.Message = await content.ReadAsStringAsync();
                }

            }
            catch (WebRequestException ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            finally
            {
                Dispose();
            }

            return result;
        }
        public async Task<string> GetCommandTextAsync()
        {
            var command = await bounder.GetCommandTextAsync();
            return command;
        }
    }
}
