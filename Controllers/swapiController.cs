using FS_Engineer_Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace FS_Engineer_Test.Controllers
{
    public class swapiController : ApiController
    {
        [Route("swapi/people")]
        public JObject Get()
        {
            JObject strresulttest = JObject.Parse(refromAPI());
            return strresulttest;
        }

        [Route("swapi/people/{id}")]
        public JObject Get(int id)
        {
            int count = 1;
            var myData = new JObject();
            string strresulttest = refromAPI();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            swapi objList = (swapi)serializer.Deserialize(strresulttest, typeof(swapi));
            

            foreach (results obj in objList.results)
            {
                if(count == id)
                {
                    myData = JObject.FromObject(obj);
                    break;
                }else
                {
                  
                }

                count++;
                
            }
            return myData;
        }

        public string refromAPI()
        {
            string strurltest = String.Format("https://swapi.dev/api/people");
            WebRequest requestObject = WebRequest.Create(strurltest);
            requestObject.Method = "GET";
            HttpWebResponse resposeobjGet = null;
            resposeobjGet = (HttpWebResponse)requestObject.GetResponse();

            string strresulttest = null;
            using (Stream stream = resposeobjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }
            return strresulttest;
        }
        public void create()
        {
           // var data = 
        }
    }
}
