using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LevelsWithDbWebApp.DAL;
using LevelsWithDbWebApp.Models;

namespace LevelsWithDbWebApp.Controllers
{
    public class SubLevelTwoesController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();



        // GET: SubLevelTwoes/Create
        public ActionResult Create(int id)
        {
            var _specificLevelOne = (from m in db.SubLevelOnes
                                      where m.SubLevelOneID == id
                                      select m).FirstOrDefault();

            return View(new SubLevelTwo() {  SubLevelOneID = id, MyLevelsHolderMugID = _specificLevelOne.MyLevelsHolderMugID });
        }

        // POST: SubLevelTwoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubLevelTwo subLevelTwo)
        {
            if (ModelState.IsValid)
            {
                var _specificLevelOne = (from m in db.SubLevelOnes
                                         where m.SubLevelOneID == subLevelTwo.SubLevelOneID
                                         select m).FirstOrDefault();

                _specificLevelOne.SubLevelTwo = subLevelTwo;
                //db.SubLevelTwos.Add(subLevelTwo);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelOne.MyLevelsHolderMugID });
            }

            return View(subLevelTwo);
        }

        // GET: SubLevelTwoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //SubLevelTwo subLevelTwo = db.SubLevelTwos.Find(id);
            var _specificLevelOne = (from m in db.SubLevelOnes
                                     .Include("SubLevelTwo")
                                     where m.SubLevelTwo.SubLevelTwoID == id
                                     select m).FirstOrDefault();

            if (_specificLevelOne == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelOne.SubLevelTwo);
        }

        // POST: SubLevelTwoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubLevelTwo subLevelTwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subLevelTwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelTwo.MyLevelsHolderMugID });
            }
            return View(subLevelTwo);
        }

        // GET: SubLevelTwoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubLevelTwo subLevelTwo = db.SubLevelTwos.Find(id);
            var _specificLevelOne = (from m in db.SubLevelOnes
                                     .Include("SubLevelTwo")
                                     where m.SubLevelTwo.SubLevelTwoID == id
                                     select m).FirstOrDefault();

            if (_specificLevelOne == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelOne.SubLevelTwo);
        }

        // POST: SubLevelTwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SubLevelTwo subLevelTwo = db.SubLevelTwos.Find(id);
            var _specificLevelOne = (from m in db.SubLevelOnes
                                      .Include("SubLevelTwo")
                                     where m.SubLevelTwo.SubLevelTwoID == id
                                     select m).FirstOrDefault();
            _specificLevelOne.SubLevelTwo = null;

           
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelOne.MyLevelsHolderMugID });
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
