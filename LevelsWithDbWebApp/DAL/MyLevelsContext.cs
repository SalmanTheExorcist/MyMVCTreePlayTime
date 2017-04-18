using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LevelsWithDbWebApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LevelsWithDbWebApp.DAL
{
    public class MyLevelsContext : DbContext

    {
        public MyLevelsContext(): base("MyLevelsDBConnectionString")
        {

        }
        //
        public DbSet<MyLevelsHolderMug> MyLevelsHolderMugs { get; set; }
        public DbSet<LevelMain> LevelMains { get; set; }
        public DbSet<SubLevelOne> SubLevelOnes { get; set; }
        public DbSet<SubLevelTwo> SubLevelTwos { get; set; }
        public DbSet<SubLevelThree> SubLevelThrees { get; set; }
        public DbSet<SubLevelFour> SubLevelFours { get; set; }
        public DbSet<SubLevelFive> SubLevelFives { get; set; }
        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //

    }
}