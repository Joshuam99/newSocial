using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities.response
{
    public class ResProfile
    { 
        public string description { get; set; }
        public int result { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int followingCount { get; set; }
        public int followerCount { get; set; }


    }
}