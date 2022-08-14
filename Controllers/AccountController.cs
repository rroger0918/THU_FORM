using Firebase.Auth;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using THU_FORM.Models;

namespace THU_FORM.Controllers
{
    public class AccountController : Controller
    {
        private static string ApiKey = "AIzaSyCWc1Pu-s4rQRetcfnyLzxpltXX7B5NCc4";
        //private static string Bucket = "https://thu-form-default-rtdb.asia-southeast1.firebasedatabase.app/";

        readonly IFirebaseClient client;
        public AccountController()
        {
            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = "TszB5Hmop1Jb64FoePa2ITKEbYmL39ZzNavOVQvA",
                BasePath = "https://thu-form-default-rtdb.asia-southeast1.firebasedatabase.app/"
            };

            client = new FirebaseClient(config);
        }




        // GET: Account
        public ActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Regist(RegistModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));

                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Name, true);
                ModelState.AddModelError(string.Empty, "驗證信傳送至您的信箱📬，敬請協助驗證，謝謝♥");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "系統錯誤，麻煩您重新操作一次，謝謝😥");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.
                if (this.Request.IsAuthenticated)
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }
            // 尚未登入，到登入頁
            if( returnUrl == "/Home/Contact") { ViewData["NeedLoginMessage"] = "欲填寫報名表，請您先登入呦呦"; }
           
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));
                    var ab = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    string token = ab.FirebaseToken;
                    var user = ab.User;
                    if (token != "")
                    {

                        this.SignInUser(user.Email, token, false);
                        Session["UserName"] = user.DisplayName;
                        Session["UserEmail"] = user.Email;
                        TempData["Message"] = " 🤜 登入成功 ";
                        return View();

                    }
                    else
                    {
                        // Setting.
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "帳號或密碼錯誤😱，登入失敗";
                // Info
                Console.Write(ex);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        private void SignInUser(string email, string token, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private void ClaimIdentities(string username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();
            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // Info.
            return this.RedirectToAction("LogOff", "Account");
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            Session["UserEmail"] = null;
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //// 密碼重設頁(自己寫的還沒測試)
        //public ActionResult ReSetPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> ReSetPassword(RegistModel model)
        //{
        //    try
        //    {
        //        var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));

        //        await auth.SendPasswordResetEmailAsync(model.Email);
        //        ModelState.AddModelError(string.Empty, "密碼重設信件已傳送至您的信箱📬，謝謝♥");
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, "系統錯誤，麻煩您重新操作一次，謝謝😥");
        //    }

        //    return View();
        //}

    }
}