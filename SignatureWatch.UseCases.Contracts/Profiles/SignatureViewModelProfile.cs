using AutoMapper;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Converters;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Contracts.Profiles
{
    public class SignatureViewModelProfile : Profile
    {
        public SignatureViewModelProfile()
        {
            CreateMap<Signature, SignatureViewModel>()
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
                .ReverseMap();

        }
    }
}
