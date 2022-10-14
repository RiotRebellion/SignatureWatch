using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class AccordanceSertificateDTOProfile : Profile
    {
        public AccordanceSertificateDTOProfile()
        {
            CreateMap<AccordanceSertificateDTO, AccordanceSertificate>()
                .ForMember(dest =>
                    dest.RegNumber,
                    opt => opt.MapFrom(src => src.RegNum))
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
                    dest.FormularGuid,
                    opt => opt.MapFrom(src => src.FormularGuid));
        }
    }
}
