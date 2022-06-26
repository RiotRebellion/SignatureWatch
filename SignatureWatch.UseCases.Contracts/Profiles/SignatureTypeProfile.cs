using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class SignatureTypeProfile : Profile
    {
        public SignatureTypeProfile()
        {
            CreateMap<SignatureType, SignatureTypeViewModel>()
                .ReverseMap();
        }
    }
}
