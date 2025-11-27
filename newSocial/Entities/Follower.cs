using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class Follower
    {
        public int followingUserId { get; set; }
        public int followedUserId { get; set; }

        public Follower() { }   
    }
}