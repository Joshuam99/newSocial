using newSocial.Entities.request;
using newSocial.Entities.response;
using newSocial.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace webApi.Controllers
{
    public class ProfileController: ApiController
    {

        [HttpPost]
        [Route("api/Profile/LoadProfile")]

        public ResProfile LoadProfile(ReqProfile req) {
            LogProfile loadProfile = new LogProfile(); 
            return loadProfile.LoadProfile(req);
        }


        [HttpPost]
        [Route("api/Profile/LoadPictures")]

        public ResLoadProfilePictures LoadPictures(ReqLoadProfilePictures req)
        {
            LogProfile loadProfile = new LogProfile();
            return loadProfile.LoadPicutres(req);
        }

    }
}