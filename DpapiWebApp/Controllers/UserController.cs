using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DpapiWebApp.Models;
using System.Configuration;
using DecryptSecrets;

namespace DpapiWebApp.Controllers
{
    public class UserController : Controller
    {        
        // GET: User
        public ActionResult Index()
        {
            string conString = ConfigurationManager.AppSettings["EncDbCon"];

            conString = Crypto.DecryptString(conString);

            var model = new UserViewModel();

            model.Name = conString;
            model.Age = "Test Age";

            return View(model);
        }
    }
}