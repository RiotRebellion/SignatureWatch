using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class SoftwareLicenseViewModelProfile : Profile
    {
        public SoftwareLicenseViewModelProfile()
        {
            CreateMap<SoftwareLicense, SoftwareLicenseViewModel>()
                .ForMember(dest =>
                    dest.LicenseNumber,
                    opt => opt.MapFrom(src => src.LicenseNumber))
                .ForMember(dest =>
                    dest.AcquisitionDate,
                    opt => opt.MapFrom(src => src.AcquisitionDate))
                .ForMember(dest =>
                    dest.ExpirationDate,
                    opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest =>
                    dest.ContractNumber,
                    opt => opt.MapFrom(src => src.Contract.ContractNumber))
                .ForMember(dest =>
                    dest.SoftwareName,
                    opt => opt.MapFrom(src => src.Software.Name))
                .ForMember(dest =>
                    dest.SoftwareVersion,
                    opt => opt.MapFrom(src => src.Software.Version))
                .ForMember(dest =>
                    dest.SupportName,
                    opt => opt.MapFrom(src => src.Support.Name));
        }
    }
}
