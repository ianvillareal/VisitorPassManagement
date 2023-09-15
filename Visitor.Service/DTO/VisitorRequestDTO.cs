using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core;
using Visitor.Core.Domain;
using Visitor.Service.Interfaces;

namespace Visitor.Service.DTO
{
    public class VisitorRequestDTO : IUpdateEntity
    {
        public long RequestId { get; set; }
        public string RequestorId { get; set; }
        public string Requestor { get; set; }
        public string Company { get; set; }
        public List<VisitorDTO> Visitors { get; set; }
        public DateTime Requested { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Leave { get; set; }
        public PurposeType Purpose { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }
        public RequirementDTO Requirement { get; set; }
    }
}
