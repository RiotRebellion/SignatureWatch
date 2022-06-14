using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<RegistrationDTO, User>()
                .ForMember(dest =>
                    dest.Username,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(dest =>
                    dest.Password,
                    opt => opt.MapFrom(src => src.Password))
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}