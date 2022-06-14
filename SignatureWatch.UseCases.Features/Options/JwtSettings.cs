namespace SignatureWatch.UseCases.Features.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public TimeSpan TokenLifeTime { get; set; }
    }
}
