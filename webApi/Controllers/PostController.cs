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
    public class PostController: ApiController
    {

        [HttpPost]
        [Route("api/Post/Upload")]
        public ResPost UploadPost(ReqPost req)
        {
            LogNewPost logUpload = new LogNewPost();
            return logUpload.UploadPost(req) ;
        }


        [HttpPost]
        [Route("api/Post/LikePost")]
        public ResPost likePost(ReqLikePost req)
        {
            LogNewPost likePost = new LogNewPost();
            return likePost.LikePost(req) ; 
        }


        [HttpPost]
        [Route("api/Post/LoadPostsList")]
        public ResPostList LoadPosts(ReqPostList req) {
            LogNewPost LogLoadPosts = new LogNewPost();
            return LogLoadPosts.LoadPosts(req);
        }
    }
}