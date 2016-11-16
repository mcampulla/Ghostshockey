using AdMaiora.AppKit.Services;
using ghostshockey.it.model.Poco;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ghostshockey.it.app
{

    public class ODataList<T>
    {
        [JsonProperty("@odata.context")]
        public string Metadata { get; set; }
        [JsonProperty("@odata.count")]
        public string Count { get; set; }
        public List<T> Value { get; set; }
    }

    public static class AppController
    {
    
        public static async Task AddYear(string text, Action<object> success, Action<string> fail, Action<Exception> exception = null)
        {
            try
            {
                //var context = new GhostshockeyContainer(new Uri("http://api-ghosts.azurewebsites.net/odata"));

                //var client = new ODataClient("http://api-ghosts.azurewebsites.net/odata");

                //var res = await client
                //    .For<Year>()
                //    .Set(new Year() { Name = text, DateStart = DateTime.Now, DateEnd = DateTime.Now.AddDays(30), IsCurrent = true })
                //    .InsertEntryAsync();

                ////var context = new GhostshockeyContainer(new Uri("http://localhost:59736/odata"));

                //ghostshockey.it.api.Models.Year newyear = new ghostshockey.it.api.Models.Year();
                //newyear.Year1 = text;
                //newyear.DateStart = DateTime.Now;
                //newyear.DateEnd = DateTime.Now.AddDays(30);
                //newyear.IsCurrent = false;
                //context.AddToYears(newyear);
                //var res = await context.SaveChangesAsync();                 

                RestClient svc = new RestClient("http://api-ghosts.azurewebsites.net/");
                svc.IgnoreResponseStatusCode = true;
                RestRequest req = new RestRequest("odata/Years", Method.POST);
                req.AddJsonBody(new Year() { Name = text, DateStart = DateTime.Now });
                var res = await svc.Execute<Year>(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Poco.User user = res.Data.Content;
                    success?.Invoke(res);
                }
                else
                {
                    fail?.Invoke(res.StatusDescription);
                }

            }
            catch (Exception ex)
            {
                exception?.Invoke(ex);
            }
        }



        public static async Task GetAllYears(Action<object> success, Action<string> fail, Action<Exception> exception = null)
        {
            try
            {
                //var context = new GhostshockeyContainer(new Uri("http://api-ghosts.azurewebsites.net/odata"));
                //var years = await context.Years.IncludeTotalCount().ExecuteAsync();

                //ghostshockey.it.api.Models.Year newyear = new ghostshockey.it.api.Models.Year();
                //newyear.Year1 = "test";
                //newyear.DateStart = DateTime.Now;
                //newyear.DateEnd = DateTime.Now.AddDays(30);

                //context.AddToYears(newyear);
                //var r = await context.SaveChangesAsync();   

                //var client = new ODataClient("http://api-ghosts.azurewebsites.net/odata");

                //var res = await client
                //    .For<Year>()
                //    .FindEntriesAsync();

                //success?.Invoke(res);

                RestClient svc = new RestClient("http://api-ghosts.azurewebsites.net/");
                svc.IgnoreResponseStatusCode = true;
                RestRequest req = new RestRequest("odata/Years", Method.GET);
                var res = await svc.Execute<ODataList<Year>>(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Poco.User user = res.Data.Content;
                    success?.Invoke(res.Data);
                }
                else
                {
                    fail?.Invoke(res.StatusDescription);
                }

            }
            catch (Exception ex)
            {
                exception?.Invoke(ex);
            }
        }

    }
}

