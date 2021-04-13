using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS_Engineer_Test.Models
{
    public class results
    {
        public string name { get; set; }
        public double? height { get; set; }
        public double? mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public string[] films { get; set; }
        public string[] species { get; set; }
        public string[] vehicles { get; set; }
        public string[] starships { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }

    }

    public class swapi
    {
        public int count { get; set; }
        public string next { get; set; }
        public int? previous { get; set; }
        public IList<results> results { get; set; }
    }
    }