using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LPEntities;

namespace lykaproduct.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index( User user)
        {
            var userName = user.Email;
            var userPassword = user.Password;
            var error = user.Error;
            if(userName =="obaiah31@gmail.com" && userPassword == "123456")
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                error = "Please Enter valid Email and Password";
                return View(user);
            }
           
        }
        public ActionResult Register()
        {
            List<User> userlist = new List<User>() { 
            new User(){ID=1001,Name ="Kurnool"},
            new User(){ID=1002,Name = "Chitoor" },
            new User(){ID =1003,Name ="Kadapa"}
            };
          
            return View(userlist);
        }
        public ActionResult Forgotpassword()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
