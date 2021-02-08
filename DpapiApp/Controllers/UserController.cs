using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DpapiApp.Models;
using DecryptSecrets;

namespace DpapiApp.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration Configuration;

        public UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            string conString = this.Configuration.GetConnectionString("EncDbCon");

            conString = Crypto.DecryptString(conString);

            var model = new UserViewModel();

            model.Name = conString;
            model.Age = "Test Age";

            return View(model);
        }

        public IActionResult Display()
        {
            string conString = this.Configuration.GetConnectionString("DbCon");

            var model = new UserViewModel();

            model.Name = "Test Name";
            model.Age = "Test Age";

            return View(model);
        }
    }
}