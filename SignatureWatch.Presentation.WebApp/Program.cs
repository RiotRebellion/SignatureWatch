using SignatureWatch.Presentation.WebApp.Installers.Extentions;
using SignatureWatch.Presentation.WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignatureWatchApi V1");
        c.RoutePrefix = string.Empty;
    });
}



app.UseStaticFiles();

app.UseCustomExceptionMiddleware();
app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
