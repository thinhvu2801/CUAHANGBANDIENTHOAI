using CHBHDT63131330.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHBHDT63131330.Controllers
{
    public class tintucController : Controller
    {
        private QLbanhang db = new QLbanhang();
        // GET: tintuc

        public ActionResult Index()
        {
            return View(db.TinTucs.ToList());
        }

        public ActionResult tintucpartital()
        {
            var ip = db.TinTucs.Take(4).ToList();
            return PartialView(ip);
        }

        public ActionResult xemchitiettintuc(int MaTT = 0)
        {
            var chitiet = db.TinTucs.SingleOrDefault(n => n.MaTT == MaTT);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}