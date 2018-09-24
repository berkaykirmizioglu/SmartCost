using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartCost.Models;

namespace SmartCost.Controllers
{
    public class MaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Materials
        public ActionResult Index()
        {
            var materials = db.Materials.Include(m => m.MaterialType).Include(m => m.UnitType);
            return View(materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name");
            ViewBag.UnitTypeId = new SelectList(db.UnitTypes, "Id", "Name");
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductCode,MaterialTypeId,UnitTypeId,Width,Height,Thickness,PriceOfUnit,Description,Notes")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            ViewBag.UnitTypeId = new SelectList(db.UnitTypes, "Id", "Name", material.UnitTypeId);
            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            ViewBag.UnitTypeId = new SelectList(db.UnitTypes, "Id", "Name", material.UnitTypeId);
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductCode,MaterialTypeId,UnitTypeId,Width,Height,Thickness,PriceOfUnit,Description,Notes")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            ViewBag.UnitTypeId = new SelectList(db.UnitTypes, "Id", "Name", material.UnitTypeId);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materials.Find(id);
            db.Materials.Remove(material);
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
