using CHBHDT63131330.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CHBHDT63131330.Controllers
{
    public class sanphamController : Controller
    {
        private QLbanhang db = new QLbanhang();
        // GET: sanpham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiHang).Include(s => s.NhaCungCap);
            return View(sanPhams.ToList());
        }

        public ActionResult suapartial()
        {
            var ip = db.SanPhams.Where(n => n.MaLoai == 1).Take(4).ToList();
            return PartialView(ip);
        }

        public ActionResult raupartial()
        {
            var ip = db.SanPhams.Where(n => n.MaLoai == 2).Take(4).ToList();
            return PartialView(ip);
        }

        public ActionResult dauanpartial()  
        {
            var ip = db.SanPhams.Where(n => n.MaLoai == 3).Take(4).ToList();
            return PartialView(ip);
        }

        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.SanPhams.SingleOrDefault(n => n.MaSP == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }


        public ActionResult xemchitietdanhmuc(int MaLoai)
        {
            var ip = db.SanPhams.Where(n => n.MaLoai == MaLoai).ToList();
            return PartialView(ip);

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