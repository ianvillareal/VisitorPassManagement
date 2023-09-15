using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Core;

namespace Visitor.Main.ViewModels
{
    public class VisitorSearchFilterViewModel
    {
        public VisitorSearchFilterViewModel()
        {
            this.Visitors = "";
            // this.Status = StatusType.ForApproval;
        }
        public string RequestorId { get; set; }
        public string Company { get; set; }
        public string Visitors { get; set; }
        //public DateTime Requested { get; set; }
        //public DateTime Arrival { get; set; }
        //public DateTime Leave { get; set; }
        //public PurposeType Purpose { get; set; }
        //public StatusType Status { get; set; }
    }
}