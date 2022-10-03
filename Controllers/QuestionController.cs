using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuize.Models;

namespace OnlineQuize.Controllers
{
    public class QuestionController : Controller
    {
        private Db_Context db = new Db_Context();
        // GET: Question
        [HttpGet]
        public ActionResult AddQuestion()
        {
            int id= Convert.ToInt32(Session["Id"]);
            List<Category> list = db.Categories.Where(model => model.AdminId== id).ToList();
            ViewBag.catlist = new SelectList(list, "CId", "CName");
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestion( Question qmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddQuestion");
            }
                int id = Convert.ToInt32(Session["Id"]);
                List<Category> list = db.Categories.Where(model => model.AdminId == id).ToList();
                ViewBag.catlist = new SelectList(list, "CId", "CName");
                Question qn = new Question();
                qn.QName = qmodel.QName;
                qn.OpA = qmodel.OpA;
                qn.OpB = qmodel.OpB;
                qn.OpC = qmodel.OpC;
                qn.OpD = qmodel.OpD;
                qn.CuurectAns = qmodel.CuurectAns;
                qn.CatId = qmodel.CatId;

                db.Questions.Add(qn);
                db.SaveChanges();
                TempData["msg"] = "Questions Added";
                TempData.Keep();
                return RedirectToAction("AddQuestion");   
        }
        public ActionResult ViewQuestion(int cid)
        {
            List<Question> qlist = db.Questions.Where(model => model.CatId == cid).ToList();
            ViewBag.Qlist = qlist;
            
            return View();
        }
        [HttpGet]
        public ActionResult UpdateQuestion(int Qid,int CatId)
        {
            //List<Question> qUp = db.Questions.Where(model => model.QId == Qid).ToList();
            //Question qUp = db.Questions.Find(Qid);
            Session["catid"] = CatId;
            Question qUp = db.Questions.Where(x => x.QId == Qid && x.CatId==CatId).FirstOrDefault();
            return View(qUp);
        }
        [HttpPost]
        public ActionResult UpdateQuestion(Question qmodel)
        {
            
            db.Entry(qmodel).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.msg = "Update Successfully";
            return View();
        }
        [HttpPost]
        public ActionResult DeleteQuestion(int Qid, int CatId)
        {
            Question qd = db.Questions.Where(x => x.QId == Qid && x.CatId == CatId).FirstOrDefault();
            db.Questions.Remove(qd);
            db.SaveChanges();
            return RedirectToAction("ViewQuestion");        
        }
        public ActionResult Roomno()
        {
            return View();

        
        }

    }
}