using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFilm.Models;

namespace WebFilm.Areas.Admin.Controllers
{
    public class Table_FimController : Controller
    {
        private WebFilmEntities2 db = new WebFilmEntities2();

        // GET: Admin/Table_Fim
        public ActionResult Index()
        {
            var table_Fim = db.Table_Fim.Include(t => t.Table_TheLoai).Include(t => t.Table_Username);
            return View(table_Fim.ToList());
        }

        // GET: Admin/Table_Fim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
                return HttpNotFound();
            }
            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Create
        public ActionResult Create()
        {
            ViewBag.IDTheLoai = new SelectList(db.Table_TheLoai, "IDTheLoai", "NameTheLoai");
            ViewBag.IDUserName = new SelectList(db.Table_Username, "IDUserName", "NameUser");
            return View();
        }

        // POST: Admin/Table_Fim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFim,NameFim,IDTheLoai,TenDienVien,AnhDienVien,ThongTinBoFim,DaoDien,NamSanXuat,NoiSanXuat,Rating,IDUserName,AnhPhim,Slide,url")] Table_Fim table_Fim)
        {
            if (ModelState.IsValid)
            {
                db.Table_Fim.Add(table_Fim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTheLoai = new SelectList(db.Table_TheLoai, "IDTheLoai", "NameTheLoai", table_Fim.IDTheLoai);
            ViewBag.IDUserName = new SelectList(db.Table_Username, "IDUserName", "NameUser", table_Fim.IDUserName);
            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTheLoai = new SelectList(db.Table_TheLoai, "IDTheLoai", "NameTheLoai", table_Fim.IDTheLoai);
            ViewBag.IDUserName = new SelectList(db.Table_Username, "IDUserName", "NameUser", table_Fim.IDUserName);
            return View(table_Fim);
        }

        // POST: Admin/Table_Fim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFim,NameFim,IDTheLoai,TenDienVien,AnhDienVien,ThongTinBoFim,DaoDien,NamSanXuat,NoiSanXuat,Rating,IDUserName,AnhPhim,Slide,url")] Table_Fim table_Fim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Fim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTheLoai = new SelectList(db.Table_TheLoai, "IDTheLoai", "NameTheLoai", table_Fim.IDTheLoai);
            ViewBag.IDUserName = new SelectList(db.Table_Username, "IDUserName", "NameUser", table_Fim.IDUserName);
            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
                return HttpNotFound();
            }
            return View(table_Fim);
        }

        // POST: Admin/Table_Fim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            db.Table_Fim.Remove(table_Fim);
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
