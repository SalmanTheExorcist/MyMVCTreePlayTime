using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class SubLevelThree
    {
        public int SubLevelThreeID { get; set; }
        [Display(Name = "SubLevel-Three-Title")]
        public string Title { get; set; }
        public SubLevelFour SubLevelFour { get; set; }


        //--just to make our lives easier below
        public int SubLevelTwoID { get; set; }
        public int MyLevelsHolderMugID { get; set; }

    }
}