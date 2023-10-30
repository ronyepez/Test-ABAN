using API_ABAN.Data;
using API_ABAN.Repositories;
using API_ABAN.Repositories.IRepositories;
using API_ABAN.Services;
using API_ABAN.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opciones =>
    opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Test Ry ABAN",
        Version = "v1",
        Description = "Test ABAN",
    });

    var archivoXML=$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var rutaXML=Path.Combine(AppContext.BaseDirectory,archivoXML);
    c.IncludeXmlComments(rutaXML);
});

builder.Services.AddDbContext<ApplicatioDbContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//Inyección de Dependencias
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
