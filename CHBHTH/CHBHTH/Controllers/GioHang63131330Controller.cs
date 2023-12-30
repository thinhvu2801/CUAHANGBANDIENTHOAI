using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHBHDT63131330.Models;

namespace CHBHDT63131330.Controllers
{
    public class GioHangController : Controller
    {
        private QLbanhang db = new QLbanhang();
        // GET: GioHang
        //Lấy giỏ hàng 
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMasp, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMasp == iMasp);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMasp);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMasp == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }

        #region 
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang(FormCollection donhangForm)
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            Console.WriteLine(donhangForm);
            string diachinhanhang = donhangForm["Diachinhanhang"].ToString();
            string thanhtoan = donhangForm["MaTT"].ToString();
            int ptthanhtoan = Int32.Parse(thanhtoan);

            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            TaiKhoan kh = (TaiKhoan)Session["use"];
            List<GioHang> gh = LayGioHang();
            ddh.MaNguoiDung = kh.MaNguoiDung;
            ddh.NgayDat = DateTime.Now;
            ddh.ThanhToan = ptthanhtoan;
            ddh.DiaChiNhanHang = diachinhanhang;
            decimal tongtien = 0;
            foreach (var item in gh)
            {
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                tongtien += thanhtien;
            }
            ddh.TongTien = tongtien;
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                ctDH.MaDon = ddh.MaDon;
                ctDH.MaSP = item.iMasp;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (decimal)item.dDonGia;
                ctDH.ThanhTien = (decimal)thanhtien;
                ctDH.PhuongThucThanhToan = 1;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Donhangs");
        }
        #endregion

        public ActionResult ThanhToanDonHang()
        {

            ViewBag.MaTT = new SelectList(new[]
                {
                    new { MaTT = 1, TenPT="Thanh toán tiền mặt" },
                    new { MaTT = 2, TenPT="Thanh toán chuyển khoản" },
                }, "MaTT", "TenPT", 1);
            ViewBag.MaNguoiDung = new SelectList(db.TaiKhoans, "MaNguoiDung", "Hoten");

            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            TaiKhoan kh = (TaiKhoan)Session["use"];
            List<GioHang> gh = LayGioHang();
            decimal tongtien = 0;
            foreach (var item in gh)
            {
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                tongtien += thanhtien;
            }

            ddh.MaNguoiDung = kh.MaNguoiDung;
            ddh.NgayDat = DateTime.Now;
            ChiTietDonHang ctDH = new ChiTietDonHang();
            ViewBag.tongtien = tongtien;
            return View(ddh);

        }

    }
}