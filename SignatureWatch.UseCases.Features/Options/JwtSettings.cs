namespace SignatureWatch.UseCases.Features.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public TimeSpan TokenLifeTime { get; set; }
    }
}
