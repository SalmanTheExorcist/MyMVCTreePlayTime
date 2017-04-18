using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class LevelMain
    {
        public int LevelMainID { get; set; }
        [Display(Name = "Main-Level-Title")]
        public string Title { get; set; }
        public SubLevelOne SubLevelOne { get; set; }
        //


       //---for EF lazy loading
       public virtual MyLevelsHolderMug MyLevelsHolderMug { get; set; }
       public int MyLevelsHolderMugID { get; set; }
      //----
    }
}