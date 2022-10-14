using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class DistributionDTOProfile : Profile
    {
        public DistributionDTOProfile()
        {
            CreateMap<DistributionDTO, Distribution>()
                .ForMember(dest =>
                    dest.Number,
                    opt => opt.MapFrom(src => src.Number))
                .ForMember(dest =>
                    dest.OrgRegNumber,
                    opt => opt.MapFrom(src => src.OrgRegNumber))
                .ForMember(dest =>
                    dest.SoftwareGuid,
                    opt => opt.MapFrom(src => src.SoftwareGuid));
        }
    }
}
