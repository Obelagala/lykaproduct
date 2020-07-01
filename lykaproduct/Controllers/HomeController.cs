using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LPEntities;
using LPAccess;

namespace lykaproduct.Controllers
{
    public class HomeController : Controller
    {
        UserServices _userServices = new UserServices();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            User user = new User();
            user.UserList = _userServices.GetUserDetails();
            return View(user);

        }
        [HttpPost]
        public ActionResult Index(int userID)
        {
            return View();
        }
     
        [HttpPost]
        public ActionResult EditUserDetails(User user)
        {
            User us = new User();
            us = _userServices.UpdateUserDetails(user);
            return RedirectToAction("Index", "Account", user);

         //   return Json(user,JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult Delete(int userID)
        {
            return View();
        }        
    }
}
