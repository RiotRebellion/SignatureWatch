using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class SupportDTOProfile : Profile
    {
        public SupportDTOProfile()
        {
            CreateMap<SupportDTO, Support>()
                .ForMember(dest =>
                    dest.ActivationCode,
                    opt => opt.MapFrom(src => src.ActivationCode))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.ExpirationDate,
                    opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest =>
                    dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}
