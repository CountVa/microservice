using AutoMapper;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using User.API.Mappers;
using User.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("UserDB"))
        .UseCamelCaseNamingConvention()
    );
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MappingProfile>();
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(provider.GetService<MappingProfile>());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
