using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Core.Domain
{
    public class VisitorRequest
    {
        public VisitorRequest()
        {
            this.Status = StatusType.InProgress;
            //this.Requirement = new Requirement();
            this.Requested = DateTime.Now;
            this.Visitors = new List<VisitorIdentity>();
        }
        public long RequestId { get; set; }
        public string RequestorId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        public virtual ICollection<VisitorIdentity> Visitors { get; set; }
        //public string Visitors { get; protected set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime Requested{ get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime VisitDate { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? Arrival { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? Leave { get; set; }
        public PurposeType Purpose { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }
        public virtual Requirement Requirement { get; set; }

        //[NotMapped]
        //public string[] VisitorList
        //{
        //    get
        //    {
        //        return Visitors.Split(',');
        //    }
        //    set
        //    {
        //        var _data = value;
        //        Visitors = String.Join(",", _data.Select(p => p.ToString()).ToArray());
        //    }
        //}
    }
}
