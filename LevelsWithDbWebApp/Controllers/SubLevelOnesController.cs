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
    public class SubLevelOnesController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();

       

       

        // GET: SubLevelOnes/Create
        public ActionResult Create(int id)
        {
            var _specificLevelMain = (from m in db.LevelMains
                                      where m.LevelMainID == id
                                      select m).FirstOrDefault();

            return View(new SubLevelOne() {   LevelMainID = id, MyLevelsHolderMugID = _specificLevelMain.MyLevelsHolderMugID});

        }

        // POST: SubLevelOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubLevelOne subLevelOne)
        {
            if (ModelState.IsValid)
            {
                LevelMain _specificLevelMain = (from m in db.LevelMains
                                          where m.LevelMainID == subLevelOne.LevelMainID
                                          select m).FirstOrDefault();
                _specificLevelMain.SubLevelOne = subLevelOne;
                //db.SubLevelOnes.Add(subLevelOne);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelOne.MyLevelsHolderMugID });
            }

            return View(subLevelOne);
        }

        // GET: SubLevelOnes/Edit/5
        public ActionResult Edit(int? id)
        {
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var _specificLevelMain = (from m in db.LevelMains
                                      .Include("SubLevelOne")
                                      where m.SubLevelOne.SubLevelOneID == id
                                      select m).FirstOrDefault();


            //SubLevelOne subLevelOne = db.SubLevelOnes.Find(id);
            if (_specificLevelMain == null)
            {
                return HttpNotFound();
            }
          
            return View(_specificLevelMain.SubLevelOne);
        }

        // POST: SubLevelOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubLevelOne subLevelOne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subLevelOne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = subLevelOne.MyLevelsHolderMugID });
            }
            return View(subLevelOne);
        }

        // GET: SubLevelOnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubLevelOne subLevelOne = db.SubLevelOnes.Find(id);
            var _specificLevelMain = (from m in db.LevelMains
                                    .Include("SubLevelOne")
                                      where m.SubLevelOne.SubLevelOneID == id
                                      select m).FirstOrDefault();


            if (_specificLevelMain == null)
            {
                return HttpNotFound();
            }
            return View(_specificLevelMain.SubLevelOne);
        }

        // POST: SubLevelOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SubLevelOne subLevelOne = db.SubLevelOnes.Find(id);
            var _specificLevelMain = (from m in db.LevelMains
                                   .Include("SubLevelOne")
                                      where m.SubLevelOne.SubLevelOneID == id
                                      select m).FirstOrDefault();
            _specificLevelMain.SubLevelOne = null; 

           
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = _specificLevelMain.MyLevelsHolderMugID });
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
