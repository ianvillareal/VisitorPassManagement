using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Presentation.ViewModels;
using Visitor.Service.DTO;
using AutoMapper;

namespace Visitor.Presentation.Mapping
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile()
        {
            CreateMap<VisitorRequestDTO, VisitorSearchResultViewModel>(MemberList.Destination)
                .ForMember(vm => vm.Visitors, opt => opt.MapFrom(s => String.Join(",", s.Visitors.Select(p => p.ToString()).ToArray())));
            CreateMap<VisitorRequestDTO, VisitorViewModel>(MemberList.Destination)
                .ForMember(vm => vm.VisitorViewList, opt => opt.Ignore())
                .ForMember(vm => vm.Visitors, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(d => d.Visitors, opt => opt.MapFrom(vm => vm.VisitorList.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray()));
            CreateMap<RequirementDTO, RequirementViewModel>()
                .ReverseMap()
                .ForMember(d => d.WorkerList, opt => opt.MapFrom(vm => vm.WorkerList.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray()));
        }
    }
}