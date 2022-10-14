using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class ContractDTOProfile : Profile
    {
        public ContractDTOProfile()
        {
            CreateMap<ContractDTO, Contract>()
                .ForMember(dest =>
                    dest.ContractNumber,
                    opt => opt.MapFrom(src => src.ContractName))
                .ForMember(dest =>
                    dest.Date,
                    opt => opt.MapFrom(src => src.Date));
        }
    }
}
