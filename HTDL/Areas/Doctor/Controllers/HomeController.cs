using HTDL.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTDL.Areas.Doctor.Controllers
{
    [Authorize(Roles = "BacSi")]
    public class HomeController : Controller
    {
        // GET: Doctor/Home
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? Page)
        {
            string id = User.Identity.GetUserId();
            string Mabs = db.BacSis.SingleOrDefault(p => p.UserId == id).MaBS;
            var listLichKham = db.PhieuDatLiches.Where(p => p.CTCongViec.BacSi.MaBS == Mabs && p.TrangThai == 1).Include(p => p.BenhNhan).Include(p => p.CaKham).Include(p => p.CTCongViec).ToList();
            var ls = listLichKham.OrderBy(p => p.NgayKham).ToList();
            return View(ls);
        }
        public ActionResult Edit(string id)
        {
            var phieudatlich = db.PhieuDatLiches.SingleOrDefault(p => p.MaPDL == id.ToString());
            phieudatlich.TrangThai = 2;
            db.Entry(phieudatlich);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Huy(string id)
        {
            var phieudatlich = db.PhieuDatLiches.SingleOrDefault(p => p.MaPDL == id.ToString());
            phieudatlich.TrangThai = -1;
            db.Entry(phieudatlich);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}