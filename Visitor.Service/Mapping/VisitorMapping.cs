using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;
using Visitor.Service.DTO;

namespace Visitor.Service.Mapping
{
    public class VisitorMapping : Profile
    {
        public VisitorMapping()
        {
            CreateMap<VisitorRequest, VisitorRequestDTO>(MemberList.Destination)
                .ReverseMap();

            CreateMap<Requirement, RequirementDTO>(MemberList.Destination)
                .ReverseMap();

            CreateMap<VisitorIdentity, VisitorDTO>(MemberList.Destination)
              .ReverseMap();
        }
    }
}
