using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles.DTOs
{
    public class FormularDTOProfile : Profile
    {
        public FormularDTOProfile()
        {
            CreateMap<FormularDTO, Formular>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.SerialKey))
                .ForMember(dest =>
                    dest.OrgRegNumber,
                    opt => opt.MapFrom(src => src.OrgRegNumber))
                .ForMember(dest =>
                    dest.ProtectionKey,
                    opt => opt.MapFrom(src => src.ProtectionKey))
                .ForMember(dest =>
                    dest.DistributionGuid,
                    opt => opt.MapFrom(src => src.DistributionGuid));
        }
    }
}
