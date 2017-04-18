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
    public class LevelMainsController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();

       

       
        
       

        public ActionResult Create(int id)
        {
                      
            return View(new LevelMain() {  MyLevelsHolderMugID = id});
        }

        // POST: LevelMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LevelMain levelMain)
        {
            if (ModelState.IsValid)
            {
                var _specificMug = (from m in db.MyLevelsHolderMugs
                                    where m.MyLevelsHolderMugID == levelMain.MyLevelsHolderMugID
                                    select m).FirstOrDefault();
                _specificMug.LevelMains.Add(levelMain);
                //db.LevelMains.Add(levelMain);
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = levelMain.MyLevelsHolderMugID });
            }

            ViewBag.MyLevelsHolderMugID = new SelectList(db.MyLevelsHolderMugs, "MyLevelsHolderMugID", "MyLevelsHolderMugName", levelMain.MyLevelsHolderMugID);
            return View(levelMain);
        }

        // GET: LevelMains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelMain levelMain = db.LevelMains.Find(id);
            if (levelMain == null)
            {
                return HttpNotFound();
            }
           
            return View(levelMain);
        }

        // POST: LevelMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LevelMain levelMain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelMain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = levelMain.MyLevelsHolderMugID });

            }

            return View(levelMain);
        }

        // GET: LevelMains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelMain levelMain = db.LevelMains.Find(id);
            if (levelMain == null)
            {
                return HttpNotFound();
            }
            return View(levelMain);
        }

        // POST: LevelMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelMain levelMain = db.LevelMains.Find(id);
            db.LevelMains.Remove(levelMain);
            db.SaveChanges();
            return RedirectToAction("Details", "MyLevelsHolderMugs", new { id = levelMain.MyLevelsHolderMugID });
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
