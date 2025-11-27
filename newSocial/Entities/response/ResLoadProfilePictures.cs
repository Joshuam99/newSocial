using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Entities.response
{
    public class ResLoadProfilePictures
    {
        public int result {  get; set; }
        public string description { get; set; }

        public List<LoadProfilePictures> pictures { get; set; } = new List<LoadProfilePictures>();

        public ResLoadProfilePictures() { } 
        
    }
}