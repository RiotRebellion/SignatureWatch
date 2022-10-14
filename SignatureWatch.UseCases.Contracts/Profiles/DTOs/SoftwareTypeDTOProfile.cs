using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class SoftwareTypeDTOProfile : Profile
    {
        public SoftwareTypeDTOProfile()
        {
            CreateMap<SoftwareTypeDTO, SoftwareType>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.SoftwareLocation,
                    opt => opt.MapFrom(src => src.SoftwareLocation));
        }
    }
}
