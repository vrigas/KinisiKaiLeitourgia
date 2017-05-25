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
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            var people = db.Patients.Include(p => p.CurrentDoctor).Include(p => p.Insurance).Include(p => p.ReferrerDoctor);
            return View(people.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.CurrentDoctorId = new SelectList(db.Doctors, "Id", "Name");
            ViewBag.InsuranceID = new SelectList(db.Insurances, "Id", "Name");
            ViewBag.ReferrerDoctorId = new SelectList(db.Doctors, "Id", "Name");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,CurrentDoctorId,ReferrerDoctorId,Birthdate,InsuranceID,ParentId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentDoctorId = new SelectList(db.Doctors, "Id", "Name", patient.CurrentDoctorId);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "Id", "Name", patient.InsuranceID);
            ViewBag.ReferrerDoctorId = new SelectList(db.Doctors, "Id", "Name", patient.ReferrerDoctorId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentDoctorId = new SelectList(db.People, "Id", "Name", patient.CurrentDoctorId);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "Id", "Name", patient.InsuranceID);
            ViewBag.ReferrerDoctorId = new SelectList(db.People, "Id", "Name", patient.ReferrerDoctorId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Telephone,Workphone,Mobile,Email,Address,Info,CurrentDoctorId,ReferrerDoctorId,Birthdate,InsuranceID,ParentId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentDoctorId = new SelectList(db.People, "Id", "Name", patient.CurrentDoctorId);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "Id", "Name", patient.InsuranceID);
            ViewBag.ReferrerDoctorId = new SelectList(db.People, "Id", "Name", patient.ReferrerDoctorId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
