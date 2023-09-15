using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Core;
using Visitor.Main.Helpers;

namespace Visitor.Main.ViewModels
{
    public class VisitorSearchResultViewModel
    {
        public long RequestId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        public string Visitors { get; set; }
        public DateTime VisitDate { get; set; }
        public PurposeType Purpose { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }

        public string StatusName
        {
            get { return Status.DisplayName(); }
        }
    }
}