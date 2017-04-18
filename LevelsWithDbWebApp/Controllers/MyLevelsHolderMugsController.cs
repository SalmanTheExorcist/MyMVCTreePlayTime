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
    public class MyLevelsHolderMugsController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();

        public ActionResult LetMeSeeMyTree(int? id)
        {
            //--id is MyLevelsHolderMugID
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // MyLevelsHolderMug myLevelsHolderMug = db.MyLevelsHolderMugs.Find(id);
            MyLevelsHolderMug myLevelsHolderMug = (from m in db.MyLevelsHolderMugs
                           .Include("LevelMains")
                           .Include("LevelMains.SubLevelOne")
                            .Include("LevelMains.SubLevelOne.SubLevelTwo")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour.SubLevelFive")
                                                   where m.MyLevelsHolderMugID == id
                           select m).FirstOrDefault();

            if (myLevelsHolderMug == null)
            {
                return HttpNotFound();
            }
            return View(myLevelsHolderMug);

        }

        // GET: MyLevelsHolderMugs
        public ActionResult Index()
        {
            return View(db.MyLevelsHolderMugs.ToList());
        }

        // GET: MyLevelsHolderMugs/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // MyLevelsHolderMug myLevelsHolderMug = db.MyLevelsHolderMugs.Find(id);

            MyLevelsHolderMug myLevelsHolderMug = (from m in db.MyLevelsHolderMugs
                          .Include("LevelMains")
                          .Include("LevelMains.SubLevelOne")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour")
                          .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour.SubLevelFive")
                                                   where m.MyLevelsHolderMugID == id
                                                   select m).FirstOrDefault();

            if (myLevelsHolderMug == null)
            {
                return HttpNotFound();
            }
            return View(myLevelsHolderMug);
        }

        // GET: MyLevelsHolderMugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyLevelsHolderMugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MyLevelsHolderMugID,MyLevelsHolderMugName")] MyLevelsHolderMug myLevelsHolderMug)
        {
            if (ModelState.IsValid)
            {
                db.MyLevelsHolderMugs.Add(myLevelsHolderMug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myLevelsHolderMug);
        }

        // GET: MyLevelsHolderMugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyLevelsHolderMug myLevelsHolderMug = db.MyLevelsHolderMugs.Find(id);
            if (myLevelsHolderMug == null)
            {
                return HttpNotFound();
            }
            return View(myLevelsHolderMug);
        }

        // POST: MyLevelsHolderMugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MyLevelsHolderMugID,MyLevelsHolderMugName")] MyLevelsHolderMug myLevelsHolderMug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myLevelsHolderMug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myLevelsHolderMug);
        }

        // GET: MyLevelsHolderMugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyLevelsHolderMug myLevelsHolderMug = db.MyLevelsHolderMugs.Find(id);
            if (myLevelsHolderMug == null)
            {
                return HttpNotFound();
            }
            return View(myLevelsHolderMug);
        }

        // POST: MyLevelsHolderMugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyLevelsHolderMug myLevelsHolderMug = db.MyLevelsHolderMugs.Find(id);
            db.MyLevelsHolderMugs.Remove(myLevelsHolderMug);
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
