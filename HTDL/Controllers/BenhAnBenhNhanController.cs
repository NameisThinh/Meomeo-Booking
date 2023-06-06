using HTDL.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTDL.Controllers
{
    public class BenhAnBenhNhanController : Controller
    {
        // GET: BenhAnBenhNhan
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BenhNhans
        [Authorize(Roles = "BenhNhan")]
        public ActionResult Index(int? Page)
        {
            string id = User.Identity.GetUserId().ToString();
            string Mabn = db.BenhNhans.SingleOrDefault(p=>p.UserId== id).MaBN;
            var listBenhAn = db.PhieuDatLiches.Where(p => p.MaBN == Mabn).ToList().OrderBy(p=>p.NgayKham);
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            return View(listBenhAn.ToPagedList(pageNumber, pageSize));
        }
    }
}