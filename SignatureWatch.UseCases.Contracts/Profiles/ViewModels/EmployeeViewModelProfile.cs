using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class EmployeeViewModelProfile : Profile
    {
        public EmployeeViewModelProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Department,
                    opt => opt.MapFrom(src => src.Department))
                .ForMember(dest =>
                    dest.Post,
                    opt => opt.MapFrom(src => src.Post))
                .ForMember(dest =>
                    dest.EmployeeStatus,
                    opt => opt.MapFrom(src => src.EmployeeStatus));
        }
    }
}
