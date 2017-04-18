using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class SubLevelFour
    {
        public int SubLevelFourID { get; set; }
        [Display(Name = "SubLevel-Four-Title")]
        public string Title { get; set; }
        public SubLevelFive SubLevelFive { get; set; }


        //--just to make our lives easier below
        public int SubLevelThreeID { get; set; }
        public int MyLevelsHolderMugID { get; set; }

    }
}