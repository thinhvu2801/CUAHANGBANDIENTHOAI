using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHBHDT63131330.Models;


namespace CHBHDT63131330.Controllers
{
    public class DonhangsController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Donhangs
        // Hiển thị danh sách đơn hàng
        public ActionResult Index()
        {
            //Kiểm tra đang đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            TaiKhoan kh = (TaiKhoan)Session["use"];
            int maND = kh.MaNguoiDung;
            var donhangs = db.DonHangs.Include(d => d.TaiKhoan).Where(d => d.MaNguoiDung == maND);
            return View(donhangs.ToList());
        }

        // GET: Donhangs/Details/5
        //Hiển thị chi tiết đơn hàng
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            var chitiet = db.ChiTietDonHangs.Include(d => d.SanPham).Where(d => d.MaDon == id).ToList();
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(chitiet);
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
