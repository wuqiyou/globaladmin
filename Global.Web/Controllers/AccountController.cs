using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Framework.Security;
using Global.Service.Contract;
using Global.Web.Models;
using Microsoft.Practices.ServiceLocation;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace Global.Web.Controllers
{
    //[RequireHttps]
    public class AccountController : AdminBaseController
    {
        public const string ControllerName = "Account";
        public const string SignInAction = "SignIn";
        public const string SignOutAction = "SignOut";

        private IGeneralService Service { get; set; }

        public AccountController()
            :base(FolderType.Root)
        {
            Service = ServiceLocator.Current.GetInstance<IGeneralService>();
        }

        // GET: /Account/SignIn
        public ActionResult SignIn()
        {
            SignInViewModel model = new SignInViewModel();
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        // POST: /Account/SignIn
        [HttpPost]
        public ActionResult SignIn(SignInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserIdentity user = Service.Authenticate(model.Email, EncryptionHelper.Encrypt(model.Password));

                if (user != null)
                {
                    CurrentUserContext.Initilize(user);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.Email, model.RememberMe, 24 * 60);

                    // Encrypt the ticket.
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    // Create the cookie.
                    System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(FolderController.IndexAction, FolderController.ControllerName);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        //
        // GET: /Account/SignOut

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();

            return RedirectToAction(SignInAction);
        }
    }
}
