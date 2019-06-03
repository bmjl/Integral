using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using integral.Models;

namespace integral.Controllers
{
    public class Integral_MainController : Controller
    {
        private Model1 db = new Model1();

        // GET: Integral_Main
        public ActionResult Index()
        {
            return View(db.Integral_Main.ToList().OrderBy(m => m.Num));
        }
        [HttpGet]
        public JsonResult Index_m()
        {
            return Json(db.Integral_Main.ToList().OrderBy(m => m.Name),JsonRequestBehavior.AllowGet);
        }
        // GET: Integral_Main/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_Main integral_Main = db.Integral_Main.Find(id);
            if (integral_Main == null)
            {
                return HttpNotFound();
            }
            return View(integral_Main);
        }

        // GET: Integral_Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Integral_Main/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Num,Name,Integral")] Integral_Main integral_Main)
        {
            if (ModelState.IsValid)
            {
                db.Integral_Main.Add(integral_Main);
                db.SaveChanges();
                //添加积分增加记录
                Integral_History integral_History = new Integral_History();
                integral_History.Main_Num = integral_Main.Num;
                integral_History.Integral = integral_Main.Integral;
                integral_History.Time = DateTime.Now;

                db.Integral_History.Add(integral_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integral_Main);
        }

        // GET: Integral_Main/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_Main integral_Main = db.Integral_Main.Find(id);
            if (integral_Main == null)
            {
                return HttpNotFound();
            }
            return View(integral_Main);
        }

        // POST: Integral_Main/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Num,Name,Integral,Integral_NM")] Integral_Main integral_Main)
        {
            if (ModelState.IsValid)
            {

                integral_Main.Integral = integral_Main.Integral + integral_Main.Integral_NM;
                db.Entry(integral_Main).State = EntityState.Modified;
                db.SaveChanges();
                //添加积分增加记录
                Integral_History integral_History = new Integral_History();
                integral_History.Main_Num = integral_Main.Num;
                integral_History.Integral = integral_Main.Integral_NM;
                integral_History.Time = DateTime.Now;

                db.Integral_History.Add(integral_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integral_Main);
        }

        // GET: Integral_Main/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_Main integral_Main = db.Integral_Main.Find(id);
            if (integral_Main == null)
            {
                return HttpNotFound();
            }
            return View(integral_Main);
        }

        // POST: Integral_Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Integral_Main integral_Main = db.Integral_Main.Find(id);
            db.Integral_Main.Remove(integral_Main);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
