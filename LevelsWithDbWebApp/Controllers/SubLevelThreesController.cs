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
    public class SubLevelThreesController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();



        // GET: SubLevelThrees/Create
        public ActionResult Create(int id)
        {
            var _specificLevelTwo = (from m in db.SubLevelTwos
                                     where m.SubLevelTwoID == id
                                     select m).FirstOrDefault();
            return View(new SubLevelThree() { SubLevelTwoID = id, MyLevelsHolderMugID = _specificLevelTwo.MyLevelsHolderMugID });

      
        }

        // POST: SubLevelThrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubLevelThree subLevelThree)
        {
            if (ModelState.IsValid)
            {
                var _specificLevelTwo = (from m in db.SubLevelTwos
                                         where m.SubLevelTwoID == subLevelThree.SubLevelTwoID
                                         select m).FirstOrDefault();

                _specificLevelTwo.SubLevelThree = subLevelThree;
               // db.SubLevelThrees.Add(subLevelThree);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelTwo.MyLevelsHolderMugID });
            }

            return View(subLevelThree);
        }

        // GET: SubLevelThrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var _specificLevelTwo = (from m in db.SubLevelTwos
                                     .Include("SubLevelThree")
                                     where m.SubLevelThree.SubLevelThreeID == id
                                     select m).FirstOrDefault();

            // SubLevelThree subLevelThree = db.SubLevelThrees.Find(id);
            if (_specificLevelTwo == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelTwo.SubLevelThree);
        }

        // POST: SubLevelThrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubLevelThree subLevelThree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subLevelThree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelThree.MyLevelsHolderMugID });
            }
            return View(subLevelThree);
        }

        // GET: SubLevelThrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  SubLevelThree subLevelThree = db.SubLevelThrees.Find(id);

            var _specificLevelTwo = (from m in db.SubLevelTwos
                                   .Include("SubLevelThree")
                                     where m.SubLevelThree.SubLevelThreeID == id
                                     select m).FirstOrDefault();

            if (_specificLevelTwo == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelTwo.SubLevelThree);
        }

        // POST: SubLevelThrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // SubLevelThree subLevelThree = db.SubLevelThrees.Find(id);
            var _specificLevelTwo = (from m in db.SubLevelTwos
                                  .Include("SubLevelThree")
                                     where m.SubLevelThree.SubLevelThreeID == id
                                     select m).FirstOrDefault();

            _specificLevelTwo.SubLevelThree = null;
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelTwo.MyLevelsHolderMugID });
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
