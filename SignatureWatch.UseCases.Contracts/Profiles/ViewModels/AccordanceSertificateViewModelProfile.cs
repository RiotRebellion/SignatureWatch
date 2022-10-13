using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class AccordanceSertificateViewModelProfile : Profile
    {
        public AccordanceSertificateViewModelProfile()
        {
            CreateMap<AccordanceSertificate, AccordanceSertificateViewModel>()
                .ForMember(dest =>
                    dest.RegNumber,
                    opt => opt.MapFrom(src => src.RegNumber))
                .ForMember(dest =>
                    dest.AcquisitionDate,
                    opt => opt.MapFrom(src => src.AcquisitionDate))
                .ForMember(dest =>
                    dest.ExpirationDate,
                    opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest =>
                    dest.ProlongDate,
                    opt => opt.MapFrom(src => src.ProlongDate))
                .ForMember(dest =>
                    dest.FormularName,
                    opt => opt.MapFrom(src => src.Formular.Name))
                .ForMember(dest =>
                    dest.FormularSerialKey,
                    opt => opt.MapFrom(src => src.Formular.SerialKey));
        }
    }
}
