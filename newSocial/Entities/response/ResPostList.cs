using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities.response
{
    public class ResPostList
    {
        public List<PostToList> PostsList { get; set; }

        public bool result { get; set; }
        public string description {  get; set; }

        public ResPostList() { }
    }
}