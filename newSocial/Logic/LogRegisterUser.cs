using newSocial.DataAcess;
using newSocial.Entities.request;
using newSocial.Entities.response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace newSocial.Logic
{
    public class LogRegisterUser
    {
        ResUser res = new ResUser();

        public ResUser RegisterUser(ReqRegisterUser request)
        {
            try
            {

                if (String.IsNullOrEmpty(request.thisUser.name))
                {
                    res.errorMenssage = "name is null";
                    res.result = false;
                 
                }
                else if (String.IsNullOrEmpty(request.thisUser.lastName))
                {
                    res.errorMenssage = "lastname is null";
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(request.thisUser.username))
                {
                    res.errorMenssage = "username is null";
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(request.thisUser.email))
                {
                    res.errorMenssage = "email is null";
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(request.thisUser.pasword))
                {
                    res.errorMenssage = "password is null";
                    res.result = false;
                }else
                {
                    int? errorID = 0;
                    int? idReturn = 0;
                    string errorDescription = "";
                    DateTime today = DateTime.Today;

                    ConLinQDataContext linq = new ConLinQDataContext();


                    linq.REGISTER_USER(request.thisUser.name, request.thisUser.lastName, request.thisUser.username, request.thisUser.email, request.thisUser.pasword, today, ref idReturn, ref errorID, ref errorDescription);

                    if (errorID == 0)
                    {
                        res.result = true;
                    }
                    else
                    {
                        res.result = false;
                        res.errorMenssage = "error in db";
                    }
                }





            }
            catch (Exception ex)
            {
                res.result = false;
                res.errorMenssage = ex.Message;
            }
            return res;

        }



       


    }
}