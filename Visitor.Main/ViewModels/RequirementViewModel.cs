using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Visitor.Main.ViewModels
{
    public class RequirementViewModel
    {
        public string Plan { get; set; }
        public string Contractor { get; set; }
        [Display(Name = "Cash bond")]
        public string CashBond { get; set; }
        [Display(Name = "Worker orientation")]
        public string WorkerOrientation { get; set; }
        [Display(Name = "Workers")]
        public string[] WorkerList { get; set; }
    }
}