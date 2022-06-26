using AutoMapper;

namespace SignatureWatch.UseCases.Contracts.Converters
{
    internal class DateTimeToDateOnlyConverter : IValueConverter<DateTime, DateOnly>
    {
        public DateOnly Convert(DateTime sourceMember, ResolutionContext context)
        {
            return DateOnly.FromDateTime(sourceMember);
        }
    }
}
