using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Main.ViewModels;
using Visitor.Service.DTO;
using AutoMapper;

namespace Visitor.Main.Mapping
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile()
        {
            CreateMap<VisitorRequestDTO, VisitorSearchResultViewModel>(MemberList.Destination)
                .ForMember(vm => vm.Visitors, opt => opt.MapFrom(s => String.Join(",", s.Visitors.Select(p => string.Concat(p.FirstName, ' ', p.MiddleName, ' ', p.LastName)))));
            CreateMap<VisitorRequestDTO, VisitorRequestViewModel>(MemberList.Destination)
                .ReverseMap();
                //.ForMember(d => d.VisitorList, opt => opt.MapFrom(vm => vm.VisitorList.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray()));
            CreateMap<RequirementDTO, RequirementViewModel>()
                .ReverseMap()
                .ForMember(d => d.WorkerList, opt => opt.MapFrom(vm => vm.WorkerList.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray()));

            CreateMap<VisitorDTO, VisitorViewModel>()
                .ForMember(m => m.Index, opt => opt.Ignore())
                .ForMember(m => m.ForAddition, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}