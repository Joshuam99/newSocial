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
    public class FollowerController: ApiController
    {
        [HttpPost]
        [Route("api/Follower/Follow")]

        public ResFollower Follow(ReqFollower req) {
            LogNewFollower logNewFollower = new LogNewFollower();
            return logNewFollower.NewFollower(req);
        }


        [HttpPost]
        [Route("api/Follower/CountFollowers")]

        public ResFollower ListFollowers(ReqListFollower req)
        {
            LogNewFollower ListUserFollowers = new LogNewFollower();
            return ListUserFollowers.CountFollowers(req);
        }

        /*
        [HttpPost]
        [Route("api/Follower/ListFollowing")]

       
        public ResFollower ListFollowing(ReqListFollower req)
        {
            LogNewFollower ListUserFollowing = new LogNewFollower();
            return ListUserFollowing.ListFollowing(req);
        }
        */
    }
}