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
    public class SubLevelFivesController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();



        // GET: SubLevelFives/Create
        public ActionResult Create(int id)
        {
            var _specificLevelFour = (from m in db.SubLevelFours
                                       where m.SubLevelFourID == id
                                       select m).FirstOrDefault();

            return View(new SubLevelFive {  SubLevelFourID = id, MyLevelsHolderMugID = _specificLevelFour.MyLevelsHolderMugID });

        }

        // POST: SubLevelFives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubLevelFive subLevelFive)
        {
            if (ModelState.IsValid)
            {
                var _specificLevelFour = (from m in db.SubLevelFours
                                          where m.SubLevelFourID == subLevelFive.SubLevelFourID
                                          select m).FirstOrDefault();

                _specificLevelFour.SubLevelFive = subLevelFive;
                //db.SubLevelFives.Add(subLevelFive);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelFour.MyLevelsHolderMugID });
            }

            return View(subLevelFive);
        }

        // GET: SubLevelFives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubLevelFive subLevelFive = db.SubLevelFives.Find(id);
            var _specificLevelFour = (from m in db.SubLevelFours
                                      .Include("SubLevelFive")
                                      where m.SubLevelFive.SubLevelFiveID == id
                                      select m).FirstOrDefault();

            if (_specificLevelFour == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelFour.SubLevelFive);
        }

        // POST: SubLevelFives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SubLevelFive subLevelFive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subLevelFive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelFive.MyLevelsHolderMugID });
            }
            return View(subLevelFive);
        }

        // GET: SubLevelFives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // SubLevelFive subLevelFive = db.SubLevelFives.Find(id);
            var _specificLevelFour = (from m in db.SubLevelFours
                                     .Include("SubLevelFive")
                                      where m.SubLevelFive.SubLevelFiveID == id
                                      select m).FirstOrDefault();

            if (_specificLevelFour == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelFour.SubLevelFive);
        }

        // POST: SubLevelFives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // SubLevelFive subLevelFive = db.SubLevelFives.Find(id);

            var _specificLevelFour = (from m in db.SubLevelFours
                                    .Include("SubLevelFive")
                                      where m.SubLevelFive.SubLevelFiveID == id
                                      select m).FirstOrDefault();
            _specificLevelFour.SubLevelFive = null;
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelFour.MyLevelsHolderMugID });
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
