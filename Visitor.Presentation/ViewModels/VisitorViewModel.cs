using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Visitor.Core;
using Visitor.Core.Domain;

namespace Visitor.Presentation.ViewModels
{
    public class VisitorViewModel
    {
        public VisitorViewModel()
        {
            this.Requested = DateTime.Now;
            this.Status = StatusType.InProgress;
            //this.VisitorList = new string[] { "", "", "", "", "" };
            //this.VisitorViewList = new List<string>();
            //VisitorViewList.Add("");
            //VisitorViewList.Add("");
            //VisitorViewList.Add("");
            //VisitorViewList.Add("");
            //VisitorViewList.Add("");
            this.Arrival = DateTime.Now;
            this.Leave = this.Arrival.AddDays(1).AddTicks(-1);
        }
        public long VisitorId { get; set; }
        public string RequestorId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        [Display(Name = "List of visitors")]
        public string[] VisitorList { get; set; }
        public DateTime Requested { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Leave { get; set; }
        public PurposeType Purpose { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }
        public RequirementViewModel Requirement { get; set; }
        public List<string> VisitorViewList { get; set; }

        public string Visitors { get; set; }
    }
}