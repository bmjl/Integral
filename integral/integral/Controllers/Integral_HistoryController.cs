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
    public class Integral_HistoryController : Controller
    {
        private Model1 db = new Model1();

        // GET: Integral_History
        public ActionResult Index(int? id)
        {
            return View(db.Integral_History.Where(m=>m.Main_Num==id).ToList().OrderByDescending(m=>m.Time));
        }

        // GET: Integral_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_History integral_History = db.Integral_History.Find(id);
            if (integral_History == null)
            {
                return HttpNotFound();
            }
            return View(integral_History);
        }

        // GET: Integral_History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Integral_History/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Main_Num,Integral,Time")] Integral_History integral_History)
        {
            if (ModelState.IsValid)
            {
                integral_History.Time = DateTime.Now;
                db.Integral_History.Add(integral_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integral_History);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create_1([Bind(Include = "Id,Main_Num,Integral,Time")] Integral_History integral_History)
        {
            if (ModelState.IsValid)
            {
                integral_History.Time = DateTime.Now;
                db.Integral_History.Add(integral_History);
                db.SaveChanges();
               // return RedirectToAction("Index");
            }

           // return View(integral_History);
        }

        // GET: Integral_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_History integral_History = db.Integral_History.Find(id);
            if (integral_History == null)
            {
                return HttpNotFound();
            }
            return View(integral_History);
        }

        // POST: Integral_History/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Main_Num,Integral,Time")] Integral_History integral_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integral_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integral_History);
        }

        // GET: Integral_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral_History integral_History = db.Integral_History.Find(id);
            if (integral_History == null)
            {
                return HttpNotFound();
            }
            return View(integral_History);
        }

        // POST: Integral_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Integral_History integral_History = db.Integral_History.Find(id);
            db.Integral_History.Remove(integral_History);
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
