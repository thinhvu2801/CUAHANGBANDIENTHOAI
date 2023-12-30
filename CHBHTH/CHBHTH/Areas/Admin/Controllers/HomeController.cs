using CHBHDT63131330.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CHBHDT63131330.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        // GET: Admin/Home
        public ActionResult Index()
        {
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            //Kiểm tra nếu tên quyền Administrator mới được truy cập trang admin
            if(u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                return View();
            }

            return RedirectPermanent("~/Home/Index");
        }
    }
}