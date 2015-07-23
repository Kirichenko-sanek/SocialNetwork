using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using FluentValidation.Validators;
using SocialNetwork.BisinesLogic;
using SocialNetwork.Core;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.Filters;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Controllers
{
    [Culture]
    public class ProfileController : Controller
    {
        private readonly IUserManager<User> _managerUser;
        private readonly IPostManager<Post> _managerPost;
        private readonly IFriendsManager<Friends> _managerFriends;

        public ProfileController(IUserManager<User> managerUser, IPostManager<Post> managerPost, IFriendsManager<Friends> managerFriends )
        {
            _managerUser = managerUser;
            _managerPost = managerPost;
            _managerFriends = managerFriends;
        }
        public ActionResult MyPage(long? id) 
        {
            if (id != null) return MyPage(new MyPageViewModel(), id);
            var user = _managerUser.GetUserByIEmail(User.Identity.Name);
            Session["UserId"] = user.Id;
            return MyPage(new MyPageViewModel(), user.Id);
        }
        

        [HttpPost]
        public ActionResult MyPage(MyPageViewModel modelMyPage, long? id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var user = _managerUser.GetByID((long)id);
                var postsUser = _managerPost.GetUserPostsById(user.Id).OrderByDescending(x => x.date);
                List<PostViewModel> posts = new List<PostViewModel>(); 
                foreach (var post in postsUser) 
                {
                    posts.Add(Mapper.Map<Post, PostViewModel>(post));
                }
                modelMyPage = Mapper.Map<User, MyPageViewModel>(user);
                modelMyPage.Posts = posts;
                return View(modelMyPage);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(AddPostViewModel model, HttpPostedFileBase upload)
        {
            try
            {
               if (!ModelState.IsValid) return View(model);
                
                var pic = new AddPhotos();
                var pathPic = pic.AddImage(upload, Server.MapPath("~/images/Posts/"), "~/images/Posts/");

                var entity = Mapper.Map<AddPostViewModel, Post>(model);
                var userInSystem = User.Identity.Name;
                var user = _managerUser.GetUserByIEmail(userInSystem);

                entity.id_user = user.Id;          
                entity.date = DateTime.Now;
                entity.description = model.Description;
                entity.Photo = new Photo { name = pathPic };
                _managerPost.Add(entity);
                return RedirectToAction("MyPage", "Profile");

            }
            catch (Exception)
            {

                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult DeletePost(long numPost)
        {
            try
            {
                var post = _managerPost.GetPostById(numPost);
                _managerPost.Delete(post);
                return RedirectToAction("MyPage", "Profile");
            }
            catch (Exception)
            {
                return RedirectToAction("MyPage", "Profile");
            }
        }      
        [AllowAnonymous]
        public ActionResult EditPost(EditPostViewModel model, long numPost)
        {
            if (!ModelState.IsValid) return View(model);
            var post = _managerPost.GetPostById(numPost);
            model = Mapper.Map<Post, EditPostViewModel>(post);
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(EditPostViewModel model)
        {
            try
            {
                //if (!ModelState.IsValid) return View(model);
                var post = _managerPost.GetPostById(model.ID);
                post.description = model.Description;
                _managerPost.Update(post);
                return RedirectToAction("MyPage", "Profile");
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult EditProfile(EditProfileViewModel model, long numUser)
        {
            //if (!ModelState.IsValid) return View(model);
            var user = _managerUser.GetUserById(numUser);
            model = Mapper.Map<User, EditProfileViewModel>(user);
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(EditProfileViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var user = _managerUser.GetUserById(model.Id);
                

                string path = null;
                string pathPic = user.Photo.name;
                
                if (upload != null && upload.ContentLength > 0)
                {
                    var pic = new AddPhotos();
                    pathPic = pic.AddImage(upload, Server.MapPath("~/images/UploadImages/"), "~/images/UploadImages/");
                }

                user = Mapper.Map<EditProfileViewModel, User>(model,user);
                        
                user.Photo.name = pathPic;
                return RedirectToAction("MyPage", "Profile");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult EditPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(EditPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var user = _managerUser.GetUserByIEmail(User.Identity.Name);
                if (user.password != PasswordHashing.PasswordHashing.HashPassword
                    (model.Password, user.password_salt))
                    throw new Exception(Resource.WrongPassword);

                var newSalt = PasswordHashing.PasswordHashing.GenerateSaltValue();
                user.password_salt = newSalt;
                user.password = PasswordHashing.PasswordHashing.HashPassword(model.NewPassword, newSalt);
                _managerUser.Update(user);
                return RedirectToAction("MyPage", "Profile");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult FriendsPage(PageFriendViewModel model)
        {
            var user = _managerUser.GetUserByIEmail(User.Identity.Name);
            var friendsListUser = _managerFriends.GetFriendsListById(user.Id);
            
            List<FriendViewModel> accountFriends = new List<FriendViewModel>();
            List<Friends> friends = new List<Friends>();
            foreach (var friend in friendsListUser)
            {


                var friendUser = _managerUser.GetUserById(friend.id_friend);
                accountFriends.Add(Mapper.Map<User,FriendViewModel>(friendUser));
                friends.Add(friend);
                
            }
            model.Friend = accountFriends;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult News(PageNewsViewModel model)
        {
            var user = _managerUser.GetUserByIEmail(User.Identity.Name);
            var friendsListUser = _managerFriends.GetFriendsListById(user.Id);
            
            
            List<Friends> friends = new List<Friends>();
            List<PostViewModel> posts = new List<PostViewModel>();
            
            foreach (var friend in friendsListUser)
            {
                var postsUser = _managerPost.GetUserPostsById(friend.id_friend).OrderByDescending(x => x.date);
                foreach (var post in postsUser)
                {
                    posts.Add(Mapper.Map<Post, PostViewModel>(post));
                }
                
                friends.Add(friend);
            }
            model.Posts = posts;
            return View(model);
        }

    }
}