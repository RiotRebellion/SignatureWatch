using AutoMapper;

namespace SignatureWatch.UseCases.Contracts.Converters
{
    public class DateOnlyToDateTimeConverter : IValueConverter<DateOnly, DateTime>
    {
        public DateTime Convert(DateOnly sourceMember, ResolutionContext context)
        {
            return sourceMember.ToDateTime(TimeOnly.Parse("00:00:00"));
        }
    }
}
