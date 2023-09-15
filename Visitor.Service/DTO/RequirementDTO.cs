using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Service.DTO
{
    public class RequirementDTO
    {
        public string Plan { get; set; }
        public string Contractor { get; set; }
        public string CashBond { get; set; }
        public string WorkerOrientation { get; set; }
        public string[] WorkerList { get; set; }
    }
}
