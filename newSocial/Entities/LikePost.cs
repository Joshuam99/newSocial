using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class LikePost
    {
        public int likingUserID { get; set; }   
        public int postID { get; set; } 

        public LikePost() { }   

    }
}