using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class SoftwareTypeViewModelProfile : Profile
    {
        public SoftwareTypeViewModelProfile()
        {
            CreateMap<SoftwareType, SoftwareTypeViewModel>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.SoftwareLocation,
                    opt => opt.MapFrom(src => src.SoftwareLocation));
        }
    }
}
