using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles.ViewModels
{
    public class SignatureViewModelProfile : Profile
    {
        public SignatureViewModelProfile()
        {
            CreateMap<Signature, SignatureViewModel>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.SerialNumber,
                    opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest =>
                    dest.PublicKeyStartDate,
                    opt => opt.MapFrom(src => src.PublicKeyStartDate))
                .ForMember(dest =>
                    dest.PublicKeyEndDate,
                    opt => opt.MapFrom(src => src.PublicKeyEndDate))
                .ForMember(dest =>
                    dest.PrivateKeyStartDate,
                    opt => opt.MapFrom(src => src.PrivateKeyStartDate))
                .ForMember(dest =>
                    dest.PrivateKeyEndDate,
                    opt => opt.MapFrom(src => src.PrivateKeyEndDate))
                .ForMember(dest =>
                    dest.SignatureType,
                    opt => opt.MapFrom(src => src.SignatureType))
                .ForMember(dest =>
                    dest.EmployeeName,
                    opt => opt.MapFrom(src => src.Owner.Name));

            CreateMap<Signature, SignatureDetailedViewModel>()
                .IncludeBase<Signature, SignatureViewModel>()
                .ForMember(dest =>
                    dest.EmployeeDepartment,
                    opt => opt.MapFrom(src => src.Owner.Department))
                .ForMember(dest =>
                    dest.EmployeePost,
                    opt => opt.MapFrom(src => src.Owner.Post));


        }
    }
}
