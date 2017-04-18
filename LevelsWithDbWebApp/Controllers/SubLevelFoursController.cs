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
    public class SubLevelFoursController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();



        // GET: SubLevelFours/Create
        public ActionResult Create(int id)
        {
            var _specificLevelThree = (from m in db.SubLevelThrees
                                     where m.SubLevelThreeID == id
                                     select m).FirstOrDefault();
            return View(new SubLevelFour() {  SubLevelThreeID = id, MyLevelsHolderMugID = _specificLevelThree.MyLevelsHolderMugID });


      
        }

        // POST: SubLevelFours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubLevelFour subLevelFour)
        {
            if (ModelState.IsValid)
            {
                var _specificLevelThree = (from m in db.SubLevelThrees
                                           where m.SubLevelThreeID == subLevelFour.SubLevelThreeID
                                           select m).FirstOrDefault();

                _specificLevelThree.SubLevelFour = subLevelFour;
               // db.SubLevelFours.Add(subLevelFour);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelThree.MyLevelsHolderMugID });
            }

            return View(subLevelFour);
        }

        // GET: SubLevelFours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  SubLevelFour subLevelFour = db.SubLevelFours.Find(id);
            var _specificLevelThree = (from m in db.SubLevelThrees
                                        .Include("SubLevelFour")
                                       where m.SubLevelFour.SubLevelFourID == id
                                       select m).FirstOrDefault();

            if (_specificLevelThree == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelThree.SubLevelFour);
        }

        // POST: SubLevelFours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubLevelFour subLevelFour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subLevelFour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelFour.MyLevelsHolderMugID });
            }
            return View(subLevelFour);
        }

        // GET: SubLevelFours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // SubLevelFour subLevelFour = db.SubLevelFours.Find(id);
            var _specificLevelThree = (from m in db.SubLevelThrees
                                        .Include("SubLevelFour")
                                       where m.SubLevelFour.SubLevelFourID == id
                                       select m).FirstOrDefault();

            if (_specificLevelThree == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelThree.SubLevelFour);
        }

        // POST: SubLevelFours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SubLevelFour subLevelFour = db.SubLevelFours.Find(id);

            var _specificLevelThree = (from m in db.SubLevelThrees
                                       .Include("SubLevelFour")
                                       where m.SubLevelFour.SubLevelFourID == id
                                       select m).FirstOrDefault();
            _specificLevelThree.SubLevelFour = null;
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelThree.MyLevelsHolderMugID });
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
