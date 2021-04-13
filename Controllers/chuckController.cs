using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FS_Engineer_Test.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FS_Engineer_Test.Controllers
{
    public class chuckController : ApiController
    {
        [Route("chuck/category")]
        public JArray Get()
        {

            return readData();
        }
        static string host = "";

        [Route("chuck/category/{id}")]
        public string Get(string id)
        {

            return RandomJoke(id);
            // convert to json
        }

        public string RandomJoke(string query)
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
            int totalresults = parsedJson.total;
            Random total = new Random();
            int id = total.Next(1, totalresults);
            int count = 1;
            string joke = "";

            foreach (result obj in parsedJson.result)
            {
                if (count == id)
                {
                    joke = obj.value;
                    break;
                }

                count++;
            }



            // create a class  
            //get total
            //get random number from 1 to total
            // use number to get a joke
            // return joke

            return joke;
        }


        public JArray readData()
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

            return strresulttest;
        }

       
       

    }
}
