using newSocial.DataAcess;
using newSocial.Entities.request;
using newSocial.Entities.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Logic
{
    public class LogNewFollower
    {
        ResFollower res = new ResFollower();

        public ResFollower NewFollower(ReqFollower request) {
            try {

                if (request.thisFollower.followingUserId == null)
                {
                    res.errorMenssage = "followig user is null";
                    res.result = false;

                }
                else if (request.thisFollower.followedUserId == null)
                {
                    res.errorMenssage = "followed user is null";
                    res.result = false;
                }
                else {
                    int? errorID = 0;
                    string errorDescription = "";

                    ConLinQDataContext LinQ = new ConLinQDataContext();

                    LinQ.FOLLOW_AND_UNFOLLOW(request.thisFollower.followingUserId,request.thisFollower.followedUserId,ref errorID, ref errorDescription);


                    if (errorID == 0)
                    {
                        res.result = true;
                        res.errorMenssage = errorDescription;
                    }
                    else if (errorID == -1)
                    {
                        res.result = true;
                        res.errorMenssage = errorDescription;
                    }
                    else {
                        res.errorMenssage = errorDescription;   
                        res.result = true;
                    }

                }

            } catch(Exception ex) { 
                Console.WriteLine(ex.ToString());   
            
            }

            return res;
        
        
        }


        public ResFollower CountFollowers(ReqListFollower req)
        {
            if (req.ListFollwers.userId == null)
            {
                res.result = false;

            }
            else
            {
                int? followerCount = 0;

                ConLinQDataContext linQ = new ConLinQDataContext();
                linQ.COUNT_FOLLOWERS(req.ListFollwers.userId, ref followerCount);
                res.result = true;
                res.errorMenssage = followerCount.ToString();
            }
            return res;
        }

        /*
        public ResFollower ListFollowing(ReqListFollower req)
        {

            if (req.ListFollwers.userId == null)
            {
                res.result = false;

            }
            else
            {
            
                ConLinQDataContext linQ = new ConLinQDataContext();
                linQ.(req.ListFollwers.userId);
                res.result = true;
            }
            return res;
        }

        */

    }
}