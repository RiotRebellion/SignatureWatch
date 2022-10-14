using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class SoftwareDTOProfile : Profile
    {
        public SoftwareDTOProfile()
        {
            CreateMap<SoftwareDTO, Software>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Version,
                    opt => opt.MapFrom(src => src.Version))
                .ForMember(dest =>
                    dest.SoftwareTypeGuid,
                    opt => opt.MapFrom(src => src.SoftwareTypeGuid));
        }
    }
}
