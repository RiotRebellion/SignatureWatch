using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class SoftwareViewModelProfile : Profile
    {
        public SoftwareViewModelProfile()
        {
            CreateMap<Software, SoftwareViewModel>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Version,
                    opt => opt.MapFrom(src => src.Version))
                .ForMember(dest =>
                    dest.SoftwareTypeName,
                    opt => opt.MapFrom(src => src.SoftwareType.Name))
                .ForMember(dest =>
                    dest.SoftwareLocation,
                    opt => opt.MapFrom(src => src.SoftwareType.SoftwareLocation))
                .ForMember(dest =>
                    dest.DistributionNumber,
                    opt => opt.MapFrom(src => src.Distribution.Number));
        }
    }
}
