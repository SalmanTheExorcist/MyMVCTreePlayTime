using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LevelsWithDbWebApp.Models
{
    public class MyLevelsHolderMug
    {
        public int MyLevelsHolderMugID { get; set; }
        [Display(Name ="Collection Name")]
        public string MyLevelsHolderMugName { get; set; }
        //
        public virtual ICollection<LevelMain> LevelMains { get; set; }
        //
    }
}