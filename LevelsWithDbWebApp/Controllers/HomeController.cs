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
    public class HomeController : Controller
    {
        private MyLevelsContext db = new MyLevelsContext();

        public ActionResult Index()
        {

            var _allMyCollectionMugs = (from m in db.MyLevelsHolderMugs
                                                             .Include("LevelMains")
                                                             .Include("LevelMains.SubLevelOne")
                                                             .Include("LevelMains.SubLevelOne.SubLevelTwo")
                                                             .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree")
                                                             .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour")
                                                             .Include("LevelMains.SubLevelOne.SubLevelTwo.SubLevelThree.SubLevelFour.SubLevelFive")
                                                             select m).ToList();

          
            if(_allMyCollectionMugs != null)
            {
                if(_allMyCollectionMugs.Count > 0)
                {
                    return View(_allMyCollectionMugs);
                }
            }

            return View(new List<MyLevelsHolderMug>());
        }

      
    }
}