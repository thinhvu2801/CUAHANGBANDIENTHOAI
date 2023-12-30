using CHBHDT63131330.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CHBHDT63131330.Controllers
{
    public class UserController : Controller
    {
        QLbanhang db = new QLbanhang();

        // ĐĂNG KÝ
        public ActionResult Dangky()
        {
            return View();
        }

        // ĐĂNG KÝ PHƯƠNG THỨC POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky(TaiKhoan taiKhoan)
        {
            try
            {
                Session["userReg"] = taiKhoan;


                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    var check = db.TaiKhoans.FirstOrDefault(s => s.Email == taiKhoan.Email);
                    if (check == null)
                    {
                        //return RedirectToAction("Dangnhap");
                        ViewBag.RegOk = "Đăng kí thành công. Đăng nhập ngay";
                        ViewBag.isReg = true;
                        // Thêm người dùng  mới
                        db.TaiKhoans.Add(taiKhoan);
                        // Lưu lại vào cơ sở dữ liệu
                        db.SaveChanges();
                        return View("Dangky");
                    }
                    else
                    {
                        ViewBag.RegOk = "Email đã tồn tại! Vui lòng chọn 1 email khác";
                        return View("Dangky");
                    }

                }
                {
                    return View("Dangky");
                }
                    

            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.TaiKhoans.FirstOrDefault(x => x.Email.Equals(userMail) && x.Matkhau.Equals(password));

            if (islogin != null)
            {
                if (userMail == "Admin@gmail.com")
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("Dangnhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
            return View(taiKhoan);
        }

        // POST: Admin/Nguoidungs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,HoTen,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                //@ViewBag.show = "Chỉnh sửa hồ sơ thành công";
                //return View(nguoidung);
                return RedirectToAction("Profile", new { id = taiKhoan.MaNguoiDung });

            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
            return View(taiKhoan);
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
    }
}