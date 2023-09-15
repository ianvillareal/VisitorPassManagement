using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Core;

namespace Visitor.Presentation.ViewModels
{
    public class VisitorSearchResultViewModel
    {
        public long VisitorId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        public string Visitors { get; set; }
        public DateTime Arrival { get; set; }
        public PurposeType Purpose { get; set; }
        public StatusType Status { get; set; }
    }
}