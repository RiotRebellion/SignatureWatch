using AutoMapper;
using MediatR;
using SignatureWatch.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration.GetSection("Database"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "SignatureWatchAPI",
        Description = "ASP.NET 6 web api"
    });
});

var app = builder.Build();

app.UseMvc();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignatureWatchApi V!");
});

app.MapGet("/", () => "Hello World!");

app.Run();
