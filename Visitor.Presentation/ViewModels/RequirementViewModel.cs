using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitor.Presentation.ViewModels
{
    public class RequirementViewModel
    {
        public string Plan { get; set; }
        public string Contractor { get; set; }
        public string CashBond { get; set; }
        public string WorkerOrientation { get; set; }
        public string[] WorkerList { get; set; }
    }
}