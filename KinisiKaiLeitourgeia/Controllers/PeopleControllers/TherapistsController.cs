﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KinisiKaiLeitourgeia.Models;
using KinisiKaiLeitourgeia.Models.People;

namespace KinisiKaiLeitourgeia.Controllers.PeopleControllers
{
    public class TherapistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Therapists
        public ActionResult Index()
        {
            return View(db.Therapists.ToList());
        }

        // GET: Therapists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        // GET: Therapists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Therapists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,LicenceNumber,AMKA")] Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                db.Therapists.Add(therapist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(therapist);
        }

        // GET: Therapists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        // POST: Therapists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,LicenceNumber,AMKA")] Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(therapist);
        }

        // GET: Therapists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        // POST: Therapists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Therapist therapist = db.Therapists.Find(id);
            db.Therapists.Remove(therapist);
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
