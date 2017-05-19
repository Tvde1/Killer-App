using System.Web.Mvc;
using Killer_App.App_Data.Helpers.DAL.Providers;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class SigninController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SigninModel model)
        {
            if (Session["Provider"] == null) Session["Provider"] = model?.Provider ?? new Provider();
            if (model == null) model = new SigninModel();
            model.Provider = (Provider)Session["Provider"];

            var result = ((Provider)Session["Provider"]).UserProvider.ValidateUser(model.Username, model.Password);

            switch (result)
            {
                case -2:
                    {
                        model.Error = "This account doesn't exist.";
                        break;
                    }
                case -1:
                    {
                        model.Error = "This username and password don't match.";
                        break;
                    }
                default:
                    {
                        Session["User"] = ((Provider)Session["Provider"]).UserProvider.FetchUser(model.Username, model.Password);
                        return RedirectToAction("Index", "Home");
                    }
            }

            return View(model);
        }
    }
}