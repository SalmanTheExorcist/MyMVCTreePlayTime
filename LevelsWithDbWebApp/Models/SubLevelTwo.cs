using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class SubLevelTwo
    {
        public int SubLevelTwoID { get; set; }
        [Display(Name = "SubLevel-Two-Title")]
        public string Title { get; set; }
        public SubLevelThree SubLevelThree { get; set; }
        //

        //--just to make our lives easier below
        public int SubLevelOneID { get; set; }
        public int MyLevelsHolderMugID { get; set; }

     

    }
}