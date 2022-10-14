using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class SoftwareLicenceDTOProfile : Profile
    {
        public SoftwareLicenceDTOProfile()
        {
            CreateMap<SoftwareLicenseDTO, SoftwareLicense>()
                .ForMember(dest =>
                    dest.LicenseNumber,
                    opt => opt.MapFrom(src => src.LicenceNumber))
                .ForMember(dest =>
                    dest.AcquisitionDate,
                    opt => opt.MapFrom(src => src.AcquisitionDate))
                .ForMember(dest =>
                    dest.ExpirationDate,
                    opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest =>
                    dest.ContractGuid,
                    opt => opt.MapFrom(src => src.ContractGuid))
                .ForMember(dest =>
                    dest.SoftwareGuid,
                    opt => opt.MapFrom(src => src.SoftwareGuid))
                .ForMember(dest =>
                    dest.SupportGuid,
                    opt => opt.MapFrom(src => src.SupportGuid));
        }
    }
}
