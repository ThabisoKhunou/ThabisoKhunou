using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS_Engineer_Test.Models
{
    public class chuck
    {
        public int total { get; set; }
        public IList<result> result { get; set; }

    }

    public class result
    {
        public IList<string> categories { get; set; }
        public DateTime created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public DateTime updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

}