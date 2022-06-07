using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using SignatureWatch.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration.GetSection("Database"));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "SignatureWatchAPI",
        Description = "ASP.NET 6 web api"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignatureWatchApi V1");
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
