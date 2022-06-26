using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class EmployeeViewModelProfile : Profile
    {
        public EmployeeViewModelProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest =>
                    dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest =>
                    dest.SecondName,
                    opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest =>
                    dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest =>
                    dest.Department,
                    opt => opt.MapFrom(src => src.Department))
                .ReverseMap();
        }
    }
}
