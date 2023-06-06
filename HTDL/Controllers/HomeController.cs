using HTDL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTDL.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult BacSi()
        {

            var listbs = db.BacSis.ToList();
            return View(listbs);
        }
        public ActionResult DichVu() 
        {
            return View(db.DichVus.ToList());
        }
        
        public ActionResult BacSidv(string MaDv)
        {
            var lsCtcv= db.CTCongViecs.Where(p=>p.MaDV==MaDv).ToList();
            var lsCaKham=db.CaKhams.ToList();
            var data = new LichKhamModel();
            data.lsCTCV= lsCtcv;
            data.lsCaKham= lsCaKham;
            

           return View(data);
        }

        public ActionResult DatKham(string MaDv)
        {
            var lsCtcv = db.CTCongViecs.Where(p => p.MaDV == MaDv).ToList();
            var lsCaKham = db.CaKhams.ToList();
            var data = new LichKhamModel();
            data.lsCTCV = lsCtcv;
            data.lsCaKham = lsCaKham;


            return View(data);
        }

        [Authorize(Roles = "BenhNhan")]
        [HttpPost]
        public ActionResult DatKham(DateTime ngaykham,string maca,string macv)
        {
            var userid=User.Identity.GetUserId();
            int mapdl = db.PhieuDatLiches.Count();
            if (ngaykham != null&&maca!=null &&macv!=null)
            {
                var data = new PhieuDatLich();
                data.MaPDL = "PDL" + mapdl;
                data.NgayDat = DateTime.Now;
                data.NgayKham = ngaykham;
                data.MaBN = db.BenhNhans.SingleOrDefault(p=>p.UserId==userid).MaBN ;
                data.MaCV = macv;
                data.MaCa = maca;
                data.TrangThai = 0;
                db.PhieuDatLiches.Add(data);
                db.SaveChanges();
            }
            return View("index");
        }

        [Authorize]
        public ActionResult ThongTinCaNhan()
        {
            var userid = User.Identity.GetUserId();
            
                BenhNhan bn = db.BenhNhans.SingleOrDefault(p => p.UserId == userid);
                return View(bn);
            
        }


        public PartialViewResult _BacSi()
        {
            List<BacSi> bs = db.BacSis.ToList().GetRange(0,6); 

            return PartialView(bs);
        }
        public PartialViewResult _DichVu()
        {
            List<DichVu> dv = db.DichVus.ToList().GetRange(0,8);
            return PartialView(dv);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/BenhNhan/" + file.FileName));
            return "/Content/BenhNhan/" + file.FileName;
        }
    }
}