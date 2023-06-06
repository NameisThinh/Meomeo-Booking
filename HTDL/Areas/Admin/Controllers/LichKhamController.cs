using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using HTDL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HTDL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class LichKhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/LichKham
        
        public ActionResult Index()
        {
            
            return View(db.PhieuDatLiches.ToList());
        }
        [HttpPost]
        public JsonResult Edit(string id)
        {
            try
            {
                var phieudatlich = db.PhieuDatLiches.SingleOrDefault(p => p.MaPDL == id.ToString());
                phieudatlich.TrangThai = 1;
                db.Entry(phieudatlich);
                db.SaveChanges();
                return Json(new {code=200, msg = "Duyệt thành công"},JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { code = 500, msg = "Lỗi trong quá trình thực thi" }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatLich pdl = db.PhieuDatLiches.Find(id);
            if (pdl == null)
            {
                return HttpNotFound();
            }
            return View(pdl);
        }

        // POST: Admin/DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuDatLich pdl = db.PhieuDatLiches.Find(id);
            db.PhieuDatLiches.Remove(pdl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]

        public JsonResult XuatExcel(string id)
        {
            try {
                var pdl = new List<PhieuDatLich>();
                switch (id)
                {
                    case "0":
                        pdl = db.PhieuDatLiches.ToList();
                        break;
                    case "1":
                        pdl = db.PhieuDatLiches.Where(p => p.TrangThai == 0).ToList();

                        break;
                    case "2":
                        pdl = db.PhieuDatLiches.Where(p => p.TrangThai == 1).ToList();

                        break;
                    case "3":
                        pdl = db.PhieuDatLiches.Where(p => p.TrangThai == 2).ToList();

                        break;
                    case "4":
                        pdl = db.PhieuDatLiches.Where(p => p.TrangThai == -1).ToList();

                        break;

                }


                var wb = new XLWorkbook();
                var ws = wb.AddWorksheet("PhieuDatLich");
                ws.Cell("A1").Value = "Mã Phiếu";
                ws.Cell("B1").Value = "Ngày Đặt";
                ws.Cell("C1").Value = "Mã bệnh nhân";
                ws.Cell("D1").Value = "Tên bệnh nhân";
                ws.Cell("E1").Value = "Bác sĩ";
                ws.Cell("F1").Value = "Dịch vụ";
                ws.Cell("G1").Value = "Ngày khám";
                ws.Cell("H1").Value = "Ca khám";
                ws.Cell("I1").Value = "Thời gian";
                ws.Cell("J1").Value = "Trạng Thái";
                int row = 2;
                for (int i = 0; i < pdl.Count(); i++)
                {
                    ws.Cell("A" + row).Value = pdl[i].MaPDL;
                    ws.Cell("B" + row).Value = pdl[i].NgayDat;
                    ws.Cell("C" + row).Value = pdl[i].MaBN;
                    ws.Cell("D" + row).Value = pdl[i].BenhNhan.TenBN;
                    ws.Cell("E" + row).Value = pdl[i].CTCongViec.BacSi.TenBS;
                    ws.Cell("F" + row).Value = pdl[i].CTCongViec.DichVu.TenDV;
                    ws.Cell("G" + row).Value = pdl[i].NgayKham;
                    ws.Cell("H" + row).Value = pdl[i].CaKham.TenCa;
                    ws.Cell("I" + row).Value = pdl[i].CaKham.ThoiGianBD + "-" + pdl[i].CaKham.ThoiGianKT;
                    switch (pdl[i].TrangThai)
                    {
                        case -1:
                            ws.Cell("J" + row).Value = "Đã hủy";    
                            break;
                        case 0:
                            ws.Cell("J" + row).Value = "Chưa duyệt";
                            break;
                        case 1:
                            ws.Cell("J" + row).Value = "Đã duyệt";
                            break;
                        case 2:
                            ws.Cell("J" + row).Value = "Dã khám";
                            break;

                    }
                    row++;
                }
                string filename = "Export_" + DateTime.Now.Ticks + ".xlsx";
                string pathFile = Server.MapPath("~/Content/FileExcel/" + filename);

                wb.SaveAs(pathFile);
                return Json(new { code = 200, msg = filename }, JsonRequestBehavior.AllowGet);
            }
            catch { return Json(new { code = 500, msg = "Lỗi  trong quá trình thực thi" }, JsonRequestBehavior.AllowGet); }

        }
    }
}