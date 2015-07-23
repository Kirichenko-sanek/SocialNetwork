using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using SocialNetwork.BisinesLogic;
using SocialNetwork.Core;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.WEB.App_GlobalResources;
using SocialNetwork.WEB.Filters;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Controllers
{
    [Culture]
    public class AccountController : Controller
    {
        private readonly IUserManager<User> _manager;
        public AccountController(IUserManager<User> manager)
        {
            _manager = manager;
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult EndRegistration()
        {
            return View();
        }
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterViewModel model, HttpPostedFileBase upload)
        {
            try 
            {
                if (!ModelState.IsValid) return View(model);
                
                var pic = new AddPhotos();
                var pathPic = pic.AddImage(upload, Server.MapPath("~/images/UploadImages/"), "~/images/UploadImages/");
                var entity = Mapper.Map<RegisterViewModel, User>(model);

                var user = _manager.GetUserByIEmail(model.Email);
                if (user != null) throw new Exception(Resource.EmailExist);

                var salt = PasswordHashing.PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.PasswordHashing.HashPassword(entity.password, salt);
                entity.password_salt = salt;
                entity.password = pass;
                entity.Photo = new Photo { name = pathPic };
                
                _manager.Add(entity);
                entity.Useres = new List<UserInRoles>() {new UserInRoles() {id_roles = 2, id_user = entity.Id}};
                _manager.Update(entity);

                var url = Url.Action("ConfirmEmail", "Account", new { Token = entity.Id, Email = entity.email }, Request.Url.Scheme);
                _manager.SentConfirmMail(entity, url);

                return RedirectToRoute("AfterRegistration");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
            
        }
        
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmEmail(long Token, string Email)
        {
            try
            {
                var user = _manager.GetByID(Token);
                _manager.ActivateUser(user);
                return View();              
            }
            catch 
            {
                return RedirectToRoute("Default");
            }
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInViewModel modelLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                var user = _manager.GetUserByIEmail(modelLogin.EmailLogin);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var passLogin = PasswordHashing.PasswordHashing.HashPassword(modelLogin.PasswordLogin, user.password_salt);
                if (user.password != passLogin) throw new Exception(Resource.WrongPassword);
                if (!user.is_activated) throw  new Exception(Resource.NotActivated);
                FormsAuthentication.SetAuthCookie(user.email, false);
                
                return RedirectToAction("MyPage","Profile", user.Id);
            }
            catch (Exception e)
            {
                modelLogin.Error = e.Message;
                return View(modelLogin);
            }   
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult PassRecovery()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult EndPassRecovery()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PassRecovery(PassRecoveryViewModel modelPassREcovery)
        {
            try
            {
                var user = _manager.GetUserByIEmail(modelPassREcovery.Email);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var rand = new Random();
                var newPass = Convert.ToString(rand.Next(100000, 999999));          
                var salt = PasswordHashing.PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.PasswordHashing.HashPassword(newPass, salt);
                user.password_salt = salt;
                user.password = pass;
                _manager.Update(user);                
                _manager.SendPassRecovery(user, newPass);
                return RedirectToRoute("AfterPassRecovery");
            }
            catch (Exception e)
            {
                modelPassREcovery.Error = e.Message;
                return View(modelPassREcovery);
            }
        }

        
        
    }
}
