using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HDipEducationCollegeOfficial.Models;
using System.Net.Http;

namespace HDipEducationCollegeOfficial.Controllers
{
    public class StudentTblController : Controller
    {
        private EducateDB_ConString db = new EducateDB_ConString();

        // GET: StudentTbl
        public ActionResult Index()
        {
            return View(db.StudentTbls.ToList());
        }

        // GET: StudentTbl/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            return View(studentTbl);
        }

        // GET: StudentTbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentTbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,PPSNumber")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                db.StudentTbls.Add(studentTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentTbl);
        }

        // GET: StudentTbl/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            return View(studentTbl);
        }

        // POST: StudentTbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,PPSNumber")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentTbl);
        }

        // GET: StudentTbl/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }

            DecisionTbl objStoresWhatComesFromAPI = new DecisionTbl();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51637/api/");
            var apiControllerInfo = client.GetAsync("GrantDecision/"+studentTbl.PPSNumber);
            apiControllerInfo.Wait();

            var responseMessage = apiControllerInfo.Result;

            if(responseMessage.IsSuccessStatusCode)
            {
                var getInfoTask = responseMessage.Content.ReadAsAsync<DecisionTbl>();
                getInfoTask.Wait();
                objStoresWhatComesFromAPI = getInfoTask.Result;

            }

            else
            {
                objStoresWhatComesFromAPI = null;
            }

            ViewBag.GrantStatus = objStoresWhatComesFromAPI;

            return View(studentTbl);

        }

        // POST: StudentTbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            db.StudentTbls.Remove(studentTbl);
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
