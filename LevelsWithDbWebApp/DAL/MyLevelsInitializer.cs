using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LevelsWithDbWebApp.Models;

namespace LevelsWithDbWebApp.DAL
{
    public class MyLevelsInitializer :
    System.Data.Entity.CreateDatabaseIfNotExists<MyLevelsContext>
    //System.Data.Entity.DropCreateDatabaseIfModelChanges<MyLevelsContext>

    {
        protected override void Seed(MyLevelsContext context)
        {

           

            var _holderMugs = new List<MyLevelsHolderMug>
           {
               new MyLevelsHolderMug{ MyLevelsHolderMugName = "My Music Levels Collection"},
               new MyLevelsHolderMug { MyLevelsHolderMugName = "My Favorite Movies Levels Collection"},
               new MyLevelsHolderMug { MyLevelsHolderMugName = "My Boxing Matches Levels Collection"}
           };
            _holderMugs.ForEach(h => context.MyLevelsHolderMugs.Add(h));
            context.SaveChanges();


        }
    }
}