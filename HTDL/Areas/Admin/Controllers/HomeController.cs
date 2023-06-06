using HTDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTDL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index() { 
            ViewBag.PhieuDatlich = db.PhieuDatLiches.Count();   
            ViewBag.DichVu = db.DichVus.Count();
            ViewBag.User= db.BenhNhans.Count(); 
            ViewBag.BacSi = db.BacSis.Count();  
            return View();
        }
        public ActionResult QLPDL()
        {
            return View();
        }
 
    }
}