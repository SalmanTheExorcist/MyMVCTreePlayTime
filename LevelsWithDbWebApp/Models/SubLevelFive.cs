using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class SubLevelFive
    {
        public int SubLevelFiveID { get; set; }
        [Display(Name = "SubLevel-Five-Title")]
        public string Title { get; set; }

        //--just to make our lives easier below
        public int SubLevelFourID { get; set; }
        public int MyLevelsHolderMugID { get; set; }

   
    }
}