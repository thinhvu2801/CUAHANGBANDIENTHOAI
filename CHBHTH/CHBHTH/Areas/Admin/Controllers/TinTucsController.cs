using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHBHDT63131330.Models;

namespace CHBHDT63131330.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: TinTucs
        public ActionResult Index()
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.PhanQuyen);
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                return View(db.TinTucs.ToList());
            }
            return RedirectPermanent("~/Home/Index");
        }

        // GET: TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.PhanQuyen);
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TinTuc tinTuc = db.TinTucs.Find(id);
                if (tinTuc == null)
                {
                    return HttpNotFound();
                }
                return View(tinTuc);
            }
            return RedirectPermanent("~/Home/Index");
        }

        // GET: TinTucs/Create
        public ActionResult Create()
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.PhanQuyen);
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                return View();
            }
            return RedirectPermanent("~/Home/Index");
        }

        // POST: TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MaTT,TieuDe,NoiDung")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.TinTucs.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinTuc);
        }

        // GET: TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.PhanQuyen);
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                    if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TinTuc tinTuc = db.TinTucs.Find(id);
                if (tinTuc == null)
                {
                    return HttpNotFound();
                }
                return View(tinTuc);
            }
            return RedirectPermanent("~/Home/Index");
        }

        // POST: TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaTT,TieuDe,NoiDung")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }

        // GET: TinTucs/Delete/5
        public ActionResult Delete(int? id)
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.PhanQuyen);
            var u = Session["use"] as CHBHDT63131330.Models.TaiKhoan;
            if (u.PhanQuyen.TenQuyen == "Adminstrator")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
            }
            return RedirectPermanent("~/Home/Index");
        }

        // POST: TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();
            return RedirectToAction("Index");
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
