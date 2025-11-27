using newSocial.DataAcess;
using newSocial.Entities;
using newSocial.Entities.request;
using newSocial.Entities.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSocial.Logic
{
    public class LogNewPost
    {
        ResPost res = new ResPost();

        public ResPost UploadPost(ReqPost req) {
            try {
                if (req.newPost.createdByUserId == null)
                {
                    res.result = false;
                    res.errorMenssage = "no user id";
                }
                else if (req.newPost.PostImage == null)
                {
                    res.result = false;
                    res.errorMenssage = "no user id";
                }
                else {
                    int? errorID = 0;
                    string description = "";

                    ConLinQDataContext LinQ = new ConLinQDataContext();

                    LinQ.UPLOAD_POST(req.newPost.createdByUserId, req.newPost.caption,req.newPost.PostImage,ref errorID,ref description);

                    if (errorID == 1)
                    {
                        res.result = true;
                        res.errorMenssage = "Post Uploaded";

                    }
                    else {
                        res.result = false;
                        res.errorMenssage = "Post not Uploaded";

                    }


                }
            
            } catch(Exception ex) {
                res.errorMenssage = "could not connecto to db";
            }
        
        
            return res;
        }




        public ResPost LikePost(ReqLikePost req) {



            if (req.LikeThisPost.postID != null && req.LikeThisPost.likingUserID != null) {

                int? result = 0;
                string description = "";

                ConLinQDataContext linQ = new ConLinQDataContext();

                linQ.LIKE_POST(req.LikeThisPost.likingUserID, req.LikeThisPost.postID, ref result, ref description);


                if (result == 1)
                {
                    res.result = true;
                    res.errorMenssage = "post liked";
                }
                else {
                    res.result = false;
                    res.errorMenssage = "Connection error";
                }
                 
            }
                
            return res;
       
        }



        public ResPostList LoadPosts(ReqPostList req)
        {
            ResPostList res = new ResPostList();
            try
            {
                if (req.userID != null)
                {


                    int? result = 0;
                    string description = "";
                    
                    ConLinQDataContext LinQ = new ConLinQDataContext();
                    List<GetPostsFromFollowedUsersWithLikesResult> Linq_list = new List<GetPostsFromFollowedUsersWithLikesResult>();

                    
                    Linq_list = LinQ.GetPostsFromFollowedUsersWithLikes(req.userID, ref description, ref result).ToList();


                    if (result == 1)
                    {
                        res.result = true;
                        res.description = "Posts Loaded";
                        res.PostsList = this.setPosts(Linq_list);
                    }
                    else {
                        res.result = false;
                        res.description = "No Posts";
                    }
                    

                }
            }
            catch (Exception ex)
            {
               
             res.result= false;
             res.description= ex.Message;
            }
            return res;
        }

        private List<PostToList> setPosts(List<GetPostsFromFollowedUsersWithLikesResult> LinqPostList)
        {
            List<PostToList> ReturnList = new List<PostToList>();

            foreach (GetPostsFromFollowedUsersWithLikesResult EachLinq in LinqPostList)
            {
                PostToList thePost = new PostToList();
                thePost.username = EachLinq.username;
                thePost.caption = EachLinq.caption;
                thePost.postID = EachLinq.post_id;
                thePost.likes = (int)EachLinq.likes_count;
                thePost.PostImage = EachLinq.post_image.ToArray();

                ReturnList.Add(thePost);
            }

            return ReturnList;
        }



    }
}