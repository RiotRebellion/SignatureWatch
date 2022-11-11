using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class EmployeeDTOProfile : Profile
    {
        public EmployeeDTOProfile()
        {
            CreateMap<EmployeeDTO, Employee>()
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
                    opt => opt.MapFrom(opt => opt.EmployeeStatus));
        }
    }
}
