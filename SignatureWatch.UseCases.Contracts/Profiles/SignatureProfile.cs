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
                    opt => opt.ConvertUsing<DateTimeToDateOnlyConverter, DateTime>())
                .ForMember(dest =>
                    dest.PublicKeyEndDate,
                    opt => opt.ConvertUsing<DateTimeToDateOnlyConverter, DateTime>())
                .ForMember(dest =>
                    dest.PrivateKeyStartDate,
                    opt => opt.ConvertUsing<DateTimeToDateOnlyConverter, DateTime>())
                .ForMember(dest =>
                    dest.PrivateKeyEndDate,
                    opt => opt.ConvertUsing<DateTimeToDateOnlyConverter, DateTime>())
                .ForMember(dest =>
                    dest.SignatureType,
                    opt => opt.MapFrom(src => src.SignatureType));

            CreateMap<SignatureDTO, Signature>()
                .ForMember(dest =>
                    dest.SerialNumber,
                    opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest =>
                    dest.PublicKeyStartDate,
                    opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
                .ForMember(dest =>
                    dest.PublicKeyEndDate,
                    opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
                .ForMember(dest =>
                    dest.PrivateKeyStartDate,
                    opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
                .ForMember(dest =>
                    dest.PrivateKeyEndDate,
                    opt => opt.ConvertUsing<DateOnlyToDateTimeConverter, DateOnly>())
                .ForMember(dest =>
                    dest.SignatureType,
                    opt => opt.MapFrom(src => src.SignatureType));
        }
    }
}
