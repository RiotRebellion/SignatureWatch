namespace SignatureWatch.Presentation.WebApp.Middlewares
{
    public static class CustomMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder) => builder
            .UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
