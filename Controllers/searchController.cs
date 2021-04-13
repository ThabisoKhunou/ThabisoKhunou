using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FS_Engineer_Test.Models;
using System.Threading.Tasks;
using System.Threading;

namespace FS_Engineer_Test.Controllers
{
    public class searchController : ApiController
    {
        [Route("search")]
        public string get()
        {
            return searchjokes("money");
            // convert to json
        }
        static string host = "";
        static string path = "";


        public IList<string> readData(string querystr)
        {
            JArray strresulttest = null;
            string strurltest = String.Format("https://api.chucknorris.io/jokes/categories");
            WebRequest requestObject = WebRequest.Create(strurltest);
            requestObject.Method = "GET";
            HttpWebResponse resposeobjGet = null;


            resposeobjGet = (HttpWebResponse)requestObject.GetResponse();

            if (resposeobjGet.StatusCode == System.Net.HttpStatusCode.OK)
            {

                using (Stream stream = resposeobjGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strresulttest = JArray.Parse(sr.ReadToEnd());
                    sr.Close();
                }
            }

            // var input = strresulttest
            IList<string> categories = strresulttest.Select(s => (string)s).ToList();
          //  var ll = strresulttest.SelectToken("(@'money')");

            var filtered = new List<string>();

            foreach (var word in categories)
            {
                if (word == querystr)
                {
                    filtered.Add(word);
                    break;
                }
            }

            return filtered;
        }


        public void getData()
        {
            WebClient client = new WebClient();

            string strpage = client.DownloadString("http://localhost:65455/");

            string text = strpage;
        }

        public string searchjokes(string query)
        {
            host = "https://api.chucknorris.io/jokes/";
            HttpClient client = new HttpClient();
            string contentString = "";
            string uri = host + "search?query=" + System.Net.WebUtility.UrlEncode(query);

            chuck parsedJson = new chuck();
            Task.Run(async () =>
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                contentString = await response.Content.ReadAsStringAsync();
                parsedJson = (chuck)JsonConvert.DeserializeObject(contentString, typeof(chuck));
            }).Wait();

            List<string> joke = new List<string>();

            foreach (result obj in parsedJson.result)
            {
                joke.Add(obj.value);

            }

            return joke.ToString();
        }
        public void Searchcategory(string query)
        {
            host = "http://localhost:65455/";
            path = "swapi/people";
            HttpClient client = new HttpClient();

            string uri = host + path + "?search=" + System.Net.WebUtility.UrlEncode(query);

            Task.Run(async () =>
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                string contentString = await response.Content.ReadAsStringAsync();
                dynamic parsedJson = JsonConvert.DeserializeObject(contentString);
            }).Wait();

        }
    }
}
