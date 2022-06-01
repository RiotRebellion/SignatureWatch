using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTOs;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<User, RegistrationDTO>()
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