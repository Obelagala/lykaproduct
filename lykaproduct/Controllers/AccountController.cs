 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LPEntities;
using LPAccess;

namespace lykaproduct.Controllers
{
    public class AccountController : Controller
    {
        CitiesServices _citiesServices = new CitiesServices();
        UserServices _userServices = new UserServices();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            User us = new User();
            us = _userServices.GetUserLogin(user);
            if(user.UserID != 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                user.Error = "Invalid Details";
                return View(user);
            }
         

        }
        [HttpGet]
        public ActionResult Register(User user)
        {
            //var userlist = new List<User>() {
            //new User{ ID = 1001, City = "Kurnool" },
            //new User{ ID = 1002, City = "Chitoor" },
            //new User{ ID = 1003, City = "Kadapa" }
            //            };

            //user.UserList = userlist;
            List<Cities> cities = new List<Cities>();
            cities = _citiesServices.GetCities();

            user.Citylist = cities;
            
            return View(user);
        }
        [HttpPost]
        public ActionResult SaveUserDetails(User user )
        {
            User us = new User();
            us = _userServices.SaveUserDetails(user);
            return RedirectToAction("Index","Account",user);
        }
        public ActionResult Forgotpassword()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Forgotpassword(User user)
        {
            User us = new User();
            us = _userServices.updateUserPassword(user);
            if(user.UserID == 101)
            {
                return View(user);
            }
            else {
                return RedirectToAction("Index", "Account");
            }
           
        }
    }
}
