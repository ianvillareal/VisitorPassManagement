using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Visitor.Core;
using Visitor.Core.Domain;

namespace Visitor.Main.ViewModels
{
    public class VisitorRequestViewModel
    {
        public VisitorRequestViewModel()
        {
            this.Requested = DateTime.Now;
            this.Status = StatusType.InProgress;
            this.VisitDate = DateTime.Now;
        }
        public long RequestId { get; set; }
        public string RequestorId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        [Display(Name = "List of visitors")]
        public List<VisitorViewModel> Visitors { get; set; }
        public DateTime Requested { get; set; }
        [Display(Name = "Visit date")]
        public DateTime VisitDate { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Leave { get; set; }
        public PurposeType Purpose { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }
        public RequirementViewModel Requirement { get; set; }
        public string EncodeVisitors { get; set; }
    }
}