using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newSocial.DataAcess;
using newSocial.Entities;
using newSocial.Entities.request;
using newSocial.Entities.response;

namespace newSocial.Logic
{
    public class LogProfile
    {
        ResProfile res = new ResProfile();

        int? result = 0;
        public ResProfile LoadProfile(ReqProfile req) {

            if (req.thisProfile.userID == null)
            {
                result = 0;
                res.description = "No user id";
            }
            else {

                string username = "";
                string usersName = "";
                string lastname = "";
                string description = "";
                
                int? followersCount = 0;
                int? followingCount = 0;


                ConLinQDataContext linQ = new ConLinQDataContext();

                linQ.LOAD_USER_PROFILE(req.thisProfile.userID,ref username, ref usersName, ref lastname, ref followingCount, ref followersCount,ref result, ref description);



                if (result == 1)
                {
                    res.description = "profile loaded";
                    res.result =(int) result;
                    res.username = username;
                    res.name = usersName;
                    res.lastname = lastname;
                    res.followingCount = (int) followingCount;
                    res.followerCount = (int) followersCount;
                }
                else {
                   
                    res.description = "profile not loaded";

                }

            }
        
            return res;
        }



        public ResLoadProfilePictures LoadPicutres(ReqLoadProfilePictures req) {
           
            ResLoadProfilePictures res = new ResLoadProfilePictures();

            if(req.UserId == null) res.result = 0;


            try {
                string result = "";
                string description = "";

                ConLinQDataContext LinQ = new ConLinQDataContext();

                List<LOAD_PROFILE_PICTURESResult> Linq_list = new List<LOAD_PROFILE_PICTURESResult>();

                Linq_list = LinQ.LOAD_PROFILE_PICTURES(req.UserId, ref result, ref description).ToList();


                if (int.Parse(result) ==1) {
                    res.result = 1;
                    res.description=description;
                    res.pictures = setPictures(Linq_list);
                }else {

                    res.result = 0;
                    res.description = description;

                }
            
            } catch (Exception ex) {
                res.result = 0;
                res.description = ex.ToString();
            }
        

            return res;
        }



        private List<LoadProfilePictures> setPictures(List<LOAD_PROFILE_PICTURESResult> LinqPicturesList)
        {
            List<LoadProfilePictures> ReturnList = new List<LoadProfilePictures>();

            foreach (LOAD_PROFILE_PICTURESResult EachLinq in LinqPicturesList)
            {
                LoadProfilePictures pictures = new LoadProfilePictures();
                pictures.id = EachLinq.id;
                pictures.postId = EachLinq.post_id;
                pictures.pictures = EachLinq.post_image.ToArray();
                ReturnList.Add(pictures);
            }

            return ReturnList;
        }

    }
}