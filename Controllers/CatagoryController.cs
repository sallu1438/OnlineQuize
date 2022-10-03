using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuize.Models;
using OnlineQuize.security;

namespace OnlineQuize.Controllers
{
    public class CatagoryController : Controller
    {
        private Db_Context db = new Db_Context();
            // GET: Catagory
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCatagory()
        {
            Session["A_id"] = Session["Id"];
           int id =Convert.ToInt32(Session["A_id"]);
            
            List<Category> catagory = db.Categories.Where(model=>model.AdminId==id).ToList();
            ViewBag.catagory = catagory;
            
            return View();
        }
        [HttpPost]
        public ActionResult AddCatagory(Category Cmodel)
        {
              List<Category> catagory = db.Categories.ToList();
            ViewBag.catagory = catagory;
            Category ct = new Category();
            Random r = new Random();
            ct.CName = Cmodel.CName;
            ct.EncName = cryptography.encrypt(Cmodel.CName.Trim() + r.Next().ToString());
            ct.AdminId = Convert.ToInt32(Session["A_id"].ToString());
      
            db.Categories.Add(ct);
            db.SaveChanges();

            return View("Addcatagory");
        }
    }
}