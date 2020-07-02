using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LPEntities;
using System.ComponentModel;
using lykaproduct.Models;
using LPAccess;

namespace lykaproduct.Controllers
{
    public class MediaController : Controller
    {
        UserServices _userServices = new UserServices();
        // GET: Media
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Media md)
        {

            return View();
        }
        public ActionResult uploadimage()
        {
            Media md = new Media();
            md.MediaList = _userServices.GetGraphicImage();
            return View(md);
        }
        [HttpPost]
        public ActionResult uploadimage(Media image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(image != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                        string extension = Path.GetExtension(image.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        var FileName = fileName;
                        image.ImagePath = "~/Content/uploads/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);
                        image.ImageFile.SaveAs(fileName);
                        Media fum = new Media();
                        fum.Title = image.Title;
                        fum.Description = image.Description;
                        fum.ImageName = FileName;
                        fum.ImagePath = image.ImagePath;
                        _userServices.SaveImageDetails(fum);
                    }
                }
                catch (Exception) { }
            }
            ModelState.Clear();
           
                return View();
        }


        //  [HttpPost]
        //public ActionResult UploadFiles(HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            //Method 2 Get file details from HttpPostedFileBase class   

        //            if (file != null)
        //            {
        //                var filename = Path.GetFileName(file.FileName);
        //                var path = Path.Combine(Server.MapPath("~/Content/uploads"), filename);                                               
        //                file.SaveAs(path);
        //            }
        //            ViewBag.FileStatus = "File uploaded successfully.";
        //        }
        //        catch (Exception)
        //        {
        //            ViewBag.FileStatus = "Error while file uploading.";
        //        }
        //    }
        //    return View("Index");
        // }

        // GET: Media/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
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

        // GET: Media/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Media/Edit/5
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

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Media/Delete/5
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
