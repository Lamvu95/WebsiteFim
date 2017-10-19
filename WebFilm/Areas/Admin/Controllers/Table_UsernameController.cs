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
    public class Table_UsernameController : Controller
    {
        private WebFilmEntities2 db = new WebFilmEntities2();

        // GET: Admin/Table_Username
        public ActionResult Index()
        {
            return View(db.Table_Username.ToList());
        }

        // GET: Admin/Table_Username/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // GET: Admin/Table_Username/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Table_Username/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUserName,NameUser,PassUser,NgaySinh,GioiTinh,SDT,Chucvu")] Table_Username table_Username)
        {
            if (ModelState.IsValid)
            {
                db.Table_Username.Add(table_Username);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Username);
        }

        // GET: Admin/Table_Username/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // POST: Admin/Table_Username/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUserName,NameUser,PassUser,NgaySinh,GioiTinh,SDT,Chucvu")] Table_Username table_Username)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Username).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Username);
        }

        // GET: Admin/Table_Username/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // POST: Admin/Table_Username/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Username table_Username = db.Table_Username.Find(id);
            db.Table_Username.Remove(table_Username);
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
