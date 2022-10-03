using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuize.Models;
using System.IO;

namespace OnlineQuize.Controllers
{
    public class ScholarController : Controller
    {
        private Db_Context db = new Db_Context();
        // GET: Scholar
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Scholar smodel,HttpPostedFileBase imgfile)
        {
            
            try
            {
                string ImageName = Path.GetFileNameWithoutExtension(imgfile.FileName);
                string extension = Path.GetExtension(imgfile.FileName);
                ImageName = ImageName + DateTime.Now.ToString("yymmssfff") + extension;
                smodel.Profile = "~/Content/Upload/" + ImageName;
               ImageName = Path.Combine(Server.MapPath("~/Content/Upload/"), ImageName);
               imgfile.SaveAs(ImageName);

                //Scholar sc = new Scholar();
                //sc.Name = smodel.Name;
                //sc.Email = smodel.Email;
                //sc.Mobile = smodel.Mobile;
                //sc.Password = smodel.Password;
                //sc.CPassword = smodel.CPassword;
               // sc.Profile = ImageName;
                db.Scholars.Add(smodel);
                db.SaveChanges();
                TempData["msgs"] = "Data Save Successfully";
                TempData.Keep();
                return RedirectToAction("Register");

            }
            catch (Exception)
            {

                TempData["msg"] = "Data not inserted";
                TempData.Keep();
            }
            return View();

        }
        [HttpGet]
        public ActionResult sLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sLogin(Scholar smodel)
        {
            var result = db.Scholars.Where(model => model.Email == smodel.Email && model.Password == smodel.Password).FirstOrDefault();
            if (result != null)
            {
                Session["Sid"] = result.Id.ToString();
                Session["SName"] = result.Name;
                Session["Profile"] = result.Profile;
                return RedirectToAction("sDashboard");
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult profile()
        {
            int id = Convert.ToInt32(Session["Sid"]);
            var data = db.Scholars.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult logout()
        {
            Session["Sid"] = string.Empty;
            Session["Sname"] = string.Empty;
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        
        }
        public ActionResult Test()
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.list = list;
            TempData["cat"] = list;
            return View();
        
        }
        [HttpPost]
        public ActionResult Test(string qid)
        {
            List<Category> list = db.Categories.ToList();
            foreach (var item in list)
            {
                if (item.EncName == qid)
                {
                    List<Question> li = db.Questions.Where(x => x.CatId == item.CId).ToList();

                    Queue<Question> queue = new Queue<Question>();

                    foreach (Question a in li)
                    {
                        queue.Enqueue(a);

                    }
                    TempData["Questions"] = queue;
                    TempData["score"] = 0;
                    TempData.Keep();
                    return RedirectToAction("startTest");


                }
                else
                {
                    return View();
                }
            }
            return View();
        
        }
        public ActionResult startTest(string qid)
        {

            Question q = null;
            // List<Question> Qa = db.Questions.Where(x => x.Categories.EncName == qid).ToList();
            // Queue<Question> qlist =(Queue<Question>)db.Questions.Where(x => x.Categories.EncName == qid);
            if (TempData["Questions"]!= null)
            {
                Queue<Question> qlist = new Queue<Question>();

                if (qlist.Count > 0)
                {
                    q = qlist.Peek();
                    qlist.Dequeue();
                    TempData["Questions"] = qlist;
                    TempData.Keep();
                }
                else
                {
                    return RedirectToAction("finished");
                }
            }
            return View(q);
        }
        [HttpPost]
        public ActionResult startTest()
        {
            return View();
            
        }
        public ActionResult finished()
        {
            return View();
        }

        public ActionResult sDashboard()
        {
            return View();
        }


    }
}