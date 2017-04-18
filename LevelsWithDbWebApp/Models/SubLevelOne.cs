using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class SubLevelOne
    {
        public int SubLevelOneID { get; set; }
        [Display(Name = "SubLevel-One-Title")]
        public string Title { get; set; }
        public SubLevelTwo SubLevelTwo { get; set; }
        //
        //--just to make our lives easier below
        public int LevelMainID { get; set; }
        public int MyLevelsHolderMugID { get; set; }
      
    }
}