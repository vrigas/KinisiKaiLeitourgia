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
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            var people = db.Doctors.Include(d => d.DoctorSpecialty).Include(d => d.DoctorWorkplace);
            return View(people.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Name");
            ViewBag.DoctorWorkplaceId = new SelectList(db.DoctorWorkplaces, "Id", "Name");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,DoctorSpecialtyId,DoctorWorkplaceId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorSpecialtyId);
            ViewBag.DoctorWorkplaceId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorWorkplaceId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorSpecialtyId);
            ViewBag.DoctorWorkplaceId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorWorkplaceId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,DoctorSpecialtyId,DoctorWorkplaceId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorSpecialtyId);
            ViewBag.DoctorWorkplaceId = new SelectList(db.DoctorSpecialties, "Id", "Id", doctor.DoctorWorkplaceId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
