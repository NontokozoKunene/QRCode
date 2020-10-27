using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace GenerateQRcode.Controllers
{
    public class QrimagesController : Controller
    {
        private QRDBEntities db = new QRDBEntities();

        // GET: Qrimages
        public ActionResult Index()
        {
            return View(db.Qrimages.ToList());
        }

        // GET: Qrimages/Details/5
        public ActionResult Details(byte[] id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qrimage qrimage = db.Qrimages.Find(id);
            if (qrimage == null)
            {
                return HttpNotFound();
            }
            return View(qrimage);
        }

        // GET: Qrimages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qrimages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "qr_code")] Qrimage qrimage)
        {
            if (ModelState.IsValid)
            {
                db.Qrimages.Add(qrimage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qrimage);
        }

        // GET: Qrimages/Edit/5
        public ActionResult Edit(byte[] id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qrimage qrimage = db.Qrimages.Find(id);
            if (qrimage == null)
            {
                return HttpNotFound();
            }
            return View(qrimage);
        }

        // POST: Qrimages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qr_code")] Qrimage qrimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qrimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qrimage);
        }

        // GET: Qrimages/Delete/5
        public ActionResult Delete(byte[] id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qrimage qrimage = db.Qrimages.Find(id);
            if (qrimage == null)
            {
                return HttpNotFound();
            }
            return View(qrimage);
        }

        // POST: Qrimages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte[] id)
        {
            Qrimage qrimage = db.Qrimages.Find(id);
            db.Qrimages.Remove(qrimage);
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
