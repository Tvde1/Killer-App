using System;
using System.Web.Mvc;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;
using Killer_App.Models;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class SigninController : BaseController
    {
        private Provider _provider;

        // GET: Login
        public ActionResult Index()
        {
            _provider = GetProvider();
            var conn = _provider.TestConnection();
            if (conn != null)
            {
                var errorModel = new SigninModel { Error = "Can't connect to the database." };
                return View(errorModel);
            }
            if (_provider.UserProvider.CurrentUser != null)
                return LogIn(_provider.UserProvider.CurrentUser.UserName, _provider.UserProvider.CurrentUser.Password, false, true);

            var result = TrySignInWithCookies();
            if (result != null) return result;
            var model = TempData["SigninModel"] as SigninModel ?? new SigninModel { Provider = _provider };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SigninModel model)
        {
            _provider = GetProvider(model);

            var conn = _provider.TestConnection();
            if (conn != null)
            {
                var errorModel = new SigninModel { Error = "Can't connect to the database." };
                return View(errorModel);
            }

            if (model != null) return AttemptLogin(model.Username, model.Password, model.RememberMe);

            model = new SigninModel
            {
                Provider = _provider,
                Warning = "Something weird happened wtf."
            };

            return View(model);
        }

        private ActionResult TrySignInWithCookies()
        {
            var cookie = Request.Cookies["UserSettings"];

            if (cookie == null) return null;

            var password = cookie["Password"];
            var username = cookie["Username"];

            var result = _provider.UserProvider.ValidateUser(username, password);

            return result == 1 ? LogIn(username, password, true, true) : null;
        }

        private ActionResult AttemptLogin(string username, string password, bool rememberMe)
        {
            var result = _provider.UserProvider.ValidateUser(username, password);

            switch (result)
            {
                case 1:
                    {
                        return LogIn(username, password, rememberMe);
                    }
                default:
                    {
                        var model = new SigninModel();

                        switch (result)
                        {
                            case -2:
                                model.Error = "This account doesn't exist.";
                                break;
                            case -1:
                                model.Error = "This username and password don't match.";
                                break;
                            default:
                                model.Error = "An uncaught login error has occured.";
                                break;
                        }
                        return Index(model);
                    }
            }
        }



        private ActionResult LogIn(string username, string password, bool rememberme, bool isAutomatic = false)
        {
            if (!isAutomatic)
            {
                if (rememberme)
                {
                    Response.Cookies["UserSettings"]["Username"] = username;
                    Response.Cookies["UserSettings"]["Password"] = password;

                    Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(-1);
                }
            }

            _provider.UserProvider.CurrentUser = _provider.UserProvider.FetchUser(username, password);
            _provider.UserProvider.CurrentUser.Password = password;
            Session["Provider"] = _provider;
            return RedirectToAction("Index", "Home");
        }

        private Provider GetProvider(BaseModel model = null)
        {
            return Session["Provider"] != null ? (Provider)Session["Provider"] : (model?.Provider ?? new Provider());
        }
    }
}