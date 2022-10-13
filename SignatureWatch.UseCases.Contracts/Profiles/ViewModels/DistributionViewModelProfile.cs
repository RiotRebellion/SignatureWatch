using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class DistributionViewModelProfile : Profile
    {
        public DistributionViewModelProfile()
        {
            CreateMap<Distribution, DistributionViewModel>()
                .ForMember(dest =>
                    dest.Number,
                    opt => opt.MapFrom(src => src.Number))
                .ForMember(dest =>
                    dest.OrgRegNumber,
                    opt => opt.MapFrom(src => src.OrgRegNumber))
                .ForMember(dest =>
                    dest.FormularName,
                    opt => opt.MapFrom(src => src.Formular.Name))
                .ForMember(dest =>
                    dest.SoftwareName,
                    opt => opt.MapFrom(src => src.Software.Name));

        }
    }
}
