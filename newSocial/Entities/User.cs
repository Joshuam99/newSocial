using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class User
    {
        
        public string name { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string pasword { get; set; }
        public DateTime signUpdate { get; set; }


        public User() { }
    }
    
}