using CHBHDT63131330.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHBHDT63131330.Areas.Admin.Controllers
{
    public class ThongkesController : Controller
    {
        private QLbanhang db = new QLbanhang();
        // GET: Thongkes
        public ActionResult Index()
        {
            var donhangs = db.DonHangs.ToList();
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                var dataThongke = (from s in db.DonHangs
                                   join x in db.TaiKhoans on s.MaNguoiDung equals x.MaNguoiDung
                                   group s by s.MaNguoiDung into g
                                   select new ThongKes
                                   {
                                       Tennguoidung = g.FirstOrDefault().TaiKhoan.HoTen,
                                       Tongtien = g.Sum(x => x.TongTien),
                                       Dienthoai = g.FirstOrDefault().TaiKhoan.Dienthoai,
                                       Soluong = g.Count()
                                   });
                var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList();
                return View(dataFinal);
            }
            return RedirectPermanent("~/Home/Index");

         
        }
    }
}