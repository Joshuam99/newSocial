using newSocial.DataAcess;
using newSocial.Entities.request;
using newSocial.Entities.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Logic
{
    public class LogUserLogin
    {

        ResUser res = new ResUser();

        public ResUser LogUser(ReqLogUser request) {

            try {
                if (String.IsNullOrEmpty(request.thisUser.email))
                {
                    res.errorMenssage = "null email";
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(request.thisUser.pasword))
                {
                    res.errorMenssage = "null password";
                    res.result = false;
                }
                else {

                    int? userCanAccess = 0;
                    int? UserID = 0;

                    ConLinQDataContext linQ = new ConLinQDataContext();
                    linQ.LOGIN_USER(request.thisUser.email,request.thisUser.pasword, ref userCanAccess, ref UserID);

                    
                    if (userCanAccess == 1)
                    {
                        res.result = true;
                        res.userID = (int)UserID;
                        
                    }
                    else if (userCanAccess == -1)
                    {
                        res.result = false;
                        res.errorMenssage = "incorrect password";
                    }
                    else {
                        res.result = false;
                        res.errorMenssage = "user not found";
                    }
                    
                }
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return res;
        
        
        }
    }
}