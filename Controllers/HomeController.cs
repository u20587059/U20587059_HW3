using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace homework_assignment_3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
           
        }
       
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            var option = Request["fileType"];

            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = " ";

                if (option == "Document")
                { 
                    path = Path.Combine(Server.MapPath("~/Media/Documents/"), fileName);

                    //ViewBag.UploadStatus = " The file was uploaded sucessfully.";
                }
                else if(option =="Image")
                {
                    path = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);
                }
                else if(option =="Video")
                {
                    path = Path.Combine(Server.MapPath("~/Media/Videos/"), fileName);
                }
                files.SaveAs(path);
            }
            ViewBag.UploadStatus = " The file was uploaded sucessfully.";
            return RedirectToAction("Index");
        }

        public ActionResult AboutMe()
        {

            return View();

        }


    }
}