using newSocial.DataAcess;
using newSocial.Entities;
using newSocial.Entities.request;
using newSocial.Entities.response;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;

namespace newSocial.Logic
{
    public class LogSearchUser
    {
        ResSearchUser res = new ResSearchUser();
        public ResSearchUser SearchUser(ReqSearchUser request)
        {

            try
            {
                if (String.IsNullOrEmpty(request.username))
                {
                    res.usernameFound = "username is null";
                    res.userfound = 0;

                }
                else
                {


                    int? userfound = 0;
                    int? userIDFound = 0;
                    string usernameFound = ""; 


                    ConLinQDataContext linQ = new ConLinQDataContext();

                    linQ.SEARCH_USER(request.username,ref userfound, ref usernameFound, ref userIDFound);

                    if (userfound == 1)
                    {
                        res.userfound = 1;
                        res.usernameFound = usernameFound;
                        res.userID = userIDFound;
                    }
                    else
                    {
                        res.userfound = 0;
                        res.usernameFound = "";

                    }
                }


            }
            catch (Exception ex)
            {
                res.usernameFound = "could not connect";
            }
            return res;


        }

    }
}


