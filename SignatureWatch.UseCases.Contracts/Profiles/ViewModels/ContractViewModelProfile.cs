using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class ContractViewModelProfile : Profile
    {
        public ContractViewModelProfile()
        {
            CreateMap<Contract, ContractViewModel>()
                .ForMember(dest =>
                    dest.ContractNumber,
                    opt => opt.MapFrom(src => src.ContractNumber))
                .ForMember(dest =>
                    dest.Date,
                    opt => opt.MapFrom(src => src.Date));
        }
    }
}
