using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Service.DTO
{
    public class VisitorDTO
    {
        public long VisitorId { get; set; }
        public long RequestId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public string EmailAddress { get; set; }
        public string CurriculumVitae { get; set; }
        
    }
}
