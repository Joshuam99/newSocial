using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class Post
    {
        public int createdByUserId { get; set; }    
        public string username { get; set; }
        public string caption { get; set; }
        public byte[] PostImage { get; set; }

        public Post() { }

    }
}