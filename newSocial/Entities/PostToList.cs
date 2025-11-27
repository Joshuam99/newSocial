using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class PostToList
    {
        public int postID { get; set; }
        public int likes { get; set; }
        public string username { get; set; }
        public string caption { get; set; }
        public byte[] PostImage { get; set; }

        public PostToList() { }

    }
}