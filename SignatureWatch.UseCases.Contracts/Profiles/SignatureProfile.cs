using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class SignatureProfile : Profile
    {
        public SignatureProfile()
        {
            CreateMap<Signature, SignatureViewModel>().ReverseMap();
        }
    }
}
