using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class FormularViewModelProfile : Profile
    {
        public FormularViewModelProfile()
        {
            CreateMap<Formular, FormularViewModel>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.SerialKey,
                    opt => opt.MapFrom(src => src.SerialKey))
                .ForMember(dest =>
                    dest.OrgRegNumber,
                    opt => opt.MapFrom(src => src.OrgRegNumber))
                .ForMember(dest =>
                    dest.ProtectionKey,
                    opt => opt.MapFrom(src => src.ProtectionKey))
                .ForMember(dest =>
                    dest.DistributionNumber,
                    opt => opt.MapFrom(src => src.Distribution.Number));
        }
    }
}
