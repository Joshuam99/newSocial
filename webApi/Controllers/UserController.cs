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
    public class UserController:ApiController
    {
        [HttpPost]
        [Route("api/User/Register")]
        public ResUser RegisterUser(ReqRegisterUser req)
        {
            LogRegisterUser logRegisterUser = new LogRegisterUser();
            return logRegisterUser.RegisterUser(req);

        }

        [HttpPost]
        [Route("api/User/Login")]
        public ResUser LogUserIn(ReqLogUser req) 
        {
            LogUserLogin logUserLogin = new LogUserLogin();
            return logUserLogin.LogUser(req);
        }

        
        [HttpPost]
        [Route("api/User/Search")]
        public ResSearchUser SearchUser(ReqSearchUser req) {
        
            LogSearchUser LogSearchUser = new LogSearchUser();
            return LogSearchUser.SearchUser(req);
        }

    
        

    }
}