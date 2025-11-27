using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities
{
    public class LoadProfilePictures
    {
        public int id {  get; set; }
        public int postId { get; set; }
        public byte[] pictures { get; set; }

        public LoadProfilePictures() { }    
    }
}