using Mvc5CustomLogin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5CustomLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            //AccountViewModel accview = new AccountViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel accview)
        {
            
            if (ModelState.IsValid && accview.Account.Username.Equals("abc") && accview.Account.Password.Equals("123"))
            {
                Session["username"] = accview.Account.Username;
                return View("Welcome");
            }
            else
            {
                ViewBag.Error = "Account is Invalid!";
                return View("Index");
            }            
        }

        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}