using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admTarea.Models;

namespace admTarea.Controllers
{
    public class ZeballossController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Zeballoss
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Zeballos.ToList());
        }

        // GET: Zeballoss/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zeballos zeballos = db.Zeballos.Find(id);
            if (zeballos == null)
            {
                return HttpNotFound();
            }
            return View(zeballos);
        }

        // GET: Zeballoss/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zeballoss/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZeballosID,FriendofZeballos,Place,Email,Birthdate")] Zeballos zeballos)
        {
            if (ModelState.IsValid)
            {
                db.Zeballos.Add(zeballos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zeballos);
        }

        // GET: Zeballoss/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zeballos zeballos = db.Zeballos.Find(id);
            if (zeballos == null)
            {
                return HttpNotFound();
            }
            return View(zeballos);
        }

        // POST: Zeballoss/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZeballosID,FriendofZeballos,Place,Email,Birthdate")] Zeballos zeballos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zeballos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zeballos);
        }

        // GET: Zeballoss/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zeballos zeballos = db.Zeballos.Find(id);
            if (zeballos == null)
            {
                return HttpNotFound();
            }
            return View(zeballos);
        }

        // POST: Zeballoss/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zeballos zeballos = db.Zeballos.Find(id);
            db.Zeballos.Remove(zeballos);
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
