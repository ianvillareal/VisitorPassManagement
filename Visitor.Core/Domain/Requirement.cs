using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Core.Domain
{
    public class Requirement
    {
        public Requirement()
        {
            this.Name = "Construction Requests Requirements";
        }
        public long RequirementId { get; set; }
       //public long VisitorId { get; set; }
        public string Name { get; set; }
        public string Plan { get; set; }
        public string Contractor { get; set; }
        public string Workers { get; set; }
        public string CashBond { get; set; }
        public string WorkerOrientation { get; set; }

        public virtual VisitorRequest ParentRequest { get; set; }

        [NotMapped]
        public string[] WorkerList
        {
            get
            {
                return Workers.Split(',');
            }
            set
            {
                var _data = value;
                Workers = String.Join(",", _data.Select(p => p.ToString()).ToArray());
            }
        }
    }
}
