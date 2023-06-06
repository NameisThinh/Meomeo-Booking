using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HTDL.Models;

namespace HTDL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CaKhamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CaKhams
        public ActionResult Index()
        {
            return View(db.CaKhams.ToList());
        }

        // GET: Admin/CaKhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.CaKhams.Find(id);
            if (caKham == null)
            {
                return HttpNotFound();
            }
            return View(caKham);
        }

        // GET: Admin/CaKhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CaKhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCa,TenCa,ThoiGianBD,ThoiGianKT,SoLuongKham")] CaKham caKham)
        {
            if (ModelState.IsValid)
            {
                db.CaKhams.Add(caKham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caKham);
        }

        // GET: Admin/CaKhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.CaKhams.Find(id);
            if (caKham == null)
            {
                return HttpNotFound();
            }
            return View(caKham);
        }

        // POST: Admin/CaKhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCa,TenCa,ThoiGianBD,ThoiGianKT,SoLuongKham")] CaKham caKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caKham);
        }

        // GET: Admin/CaKhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.CaKhams.Find(id);
            if (caKham == null)
            {
                return HttpNotFound();
            }
            return View(caKham);
        }

        // POST: Admin/CaKhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CaKham caKham = db.CaKhams.Find(id);
            db.CaKhams.Remove(caKham);
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
