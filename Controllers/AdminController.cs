using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuize.Models;

namespace OnlineQuize.Controllers
{
   
    public class AdminController : Controller
    {
        private Db_Context db = new Db_Context();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult Login(Admin Amodel)
        {
            var result = db.Admins.Where(model => model.Email == Amodel.Email && model.Password == Amodel.Password).SingleOrDefault();
            if (result != null)
            {

                Session["Id"] = result.Id.ToString();
                Session["Email"] = result.Email;
                Session["Name"] = result.Name;

                return RedirectToAction("Dashboard", "Admin");


            }
            else
            {
                ViewBag.msg = "UserId Or Password Invalid";
                return View();

            }
        }
        public ActionResult Logout()
        {
            Session["Id"] = string.Empty;
            Session["Name"] = string.Empty;
            Session["Emai"] = string.Empty;
            Session.Abandon();
            Session.RemoveAll();

            return RedirectToAction("Login", "Admin");
        
        }
        public ActionResult Error()
        {
            return View();
        
        }
    }
}