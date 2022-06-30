using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Converters;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class SignatureProfile : Profile
    {
        public SignatureProfile()
        {
            CreateMap<Signature, SignatureDTO>()
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
                .ReverseMap();

            //CreateMap<SignatureDTO, Signature>()
            //    .ForMember(dest =>
            //        dest.SerialNumber,
            //        opt => opt.MapFrom(src => src.SerialNumber))
            //    .ForMember(dest =>
            //        dest.PublicKeyStartDate,
            //        opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
            //    .ForMember(dest =>
            //        dest.PublicKeyEndDate,
            //        opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
            //    .ForMember(dest =>
            //        dest.PrivateKeyStartDate,
            //        opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
            //    .ForMember(dest =>
            //        dest.PrivateKeyEndDate,
            //        opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
            //    .ForMember(dest =>
            //        dest.SignatureType,
            //        opt => opt.MapFrom(src => src.SignatureType));
        }
    }
}
