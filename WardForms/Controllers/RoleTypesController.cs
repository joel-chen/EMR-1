﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardFormsCore.DataModel;

namespace WardForms.Controllers
{
    public class RoleTypesController : Controller
    {
        private WardFormsCoreDataModel db = new WardFormsCoreDataModel();

        // GET: RoleTypes
        public ActionResult Index()
        {
            return View(db.RoleTypes.ToList());
        }

        // GET: RoleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleType roleType = db.RoleTypes.Find(id);
            if (roleType == null)
            {
                return HttpNotFound();
            }
            return View(roleType);
        }

        // GET: RoleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleTypeId,RoleType1")] RoleType roleType)
        {
            if (ModelState.IsValid)
            {
                db.RoleTypes.Add(roleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleType);
        }

        // GET: RoleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleType roleType = db.RoleTypes.Find(id);
            if (roleType == null)
            {
                return HttpNotFound();
            }
            return View(roleType);
        }

        // POST: RoleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleTypeId,RoleType1")] RoleType roleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleType);
        }

        // GET: RoleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleType roleType = db.RoleTypes.Find(id);
            if (roleType == null)
            {
                return HttpNotFound();
            }
            return View(roleType);
        }

        // POST: RoleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleType roleType = db.RoleTypes.Find(id);
            db.RoleTypes.Remove(roleType);
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
