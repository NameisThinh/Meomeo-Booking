using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using HTDL.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using PagedList;

namespace HTDL.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BacSisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       private ApplicationUserManager userManager;
        private ApplicationSignInManager signInManager;

        public BacSisController()
        {
        }

        public BacSisController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View(db.BacSis.ToList());
        }


        // GET: Admin/BacSis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // GET: Admin/BacSis/Create
        public ActionResult Create()
        {
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV");
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV");
            return View();
        }

        // POST: Admin/BacSis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaBS,Avt,TenBS,NgaySinh,GioiTinh,SDT,MaKhoa,MaCV,UserId")] BacSi bacSi)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.BacSis.Add(bacSi);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", bacSi.MaCV);
        //    ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
        //    return View(bacSi);
        //}

        public async Task<ActionResult> Create( BacSiViewModel bacSi)
        {
            if (ModelState.IsValid)
            {
                string Id = "User" + db.Users.Count();
                var user = new ApplicationUser { UserName = bacSi.Email, Email = bacSi.Email, Id = Id };
                var result =await UserManager.CreateAsync(user, bacSi.Email);
                if (result.Succeeded)
                {
                    var bs = new BacSi();
                    var ctcv = new CTCongViec();
                    var mabs = "BS" + db.BacSis.Count();
                    var macv = "CV"+ db.CTCongViecs.Count();
                    bs.MaBS = mabs;
                    bs.TenBS = bacSi.HoTen;
                    bs.GioiTinh = bacSi.GioiTinh;
                    bs.SDT = bacSi.SDT;
                    bs.Avt = bacSi.Avt;
                    bs.NgaySinh = bacSi.NgaySinh;
                    bs.MaKhoa = bacSi.MaKhoa;
                    bs.MaCV = bacSi.MaCV;
                    bs.UserId = Id;
                    db.BacSis.Add(bs);
                    db.SaveChanges();

                    ctcv.MaCV = macv;
                    ctcv.MaDV = bacSi.MaDV;
                    ctcv.MaBS = mabs;
                    db.CTCongViecs.Add(ctcv);
                    db.SaveChanges();

                    await UserManager.AddToRoleAsync(Id, "BacSi");

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", bacSi.MaCV);
                ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
                ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV", bacSi.MaDV);
                ViewBag.Email = "Da ton tai";
                return View(bacSi);
            }

            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", bacSi.MaCV);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV", bacSi.MaDV);
            return View(bacSi);
        }

        // GET: Admin/BacSis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", bacSi.MaCV);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
            return View(bacSi);
        }

        // POST: Admin/BacSis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBS,Avt,TenBS,NgaySinh,GioiTinh,SDT,MaKhoa,MaCV,UserId")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacSi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", bacSi.MaCV);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
            return View(bacSi);
        }

        // GET: Admin/BacSis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: Admin/BacSis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            db.BacSis.Remove(bacSi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/BacSi/" + file.FileName));
            return "/Content/BacSi/" + file.FileName;
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
