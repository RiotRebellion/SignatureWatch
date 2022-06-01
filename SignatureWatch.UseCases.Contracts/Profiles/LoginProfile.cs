using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTOs;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<User, LoginDTO>()
                .ForMember(dest =>
                    dest.Username,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(dest =>
                    dest.Password,
                    opt => opt.MapFrom(src => src.Password));
        }
    }
}
