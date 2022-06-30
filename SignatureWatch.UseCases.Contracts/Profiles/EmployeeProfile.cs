using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name)).
                ForMember(dest =>
                    dest.Department,
                    opt => opt.MapFrom(src => src.Department))
                .ForMember(dest =>
                    dest.EmployeeStatus,
                    opt => opt.MapFrom(opt => opt.EmployeeStatus))
                .ReverseMap();
        }
    }
}
