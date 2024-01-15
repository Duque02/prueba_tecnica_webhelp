using Webhelp.PruebaTecnica.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webhelp.PruebaTecnica.API.Services;
using Webhelp.PruebaTecnica.Domain.Repositories;
using Webhelp.PruebaTecnica.Infrastructure.Repositories;
using Webhelp.PruebaTecnica.API.Authentication;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup database

var dbConnectionString = builder.Configuration.GetConnectionString("MedicalCenterDB");
var serverVersion = ServerVersion.AutoDetect(dbConnectionString);

builder.Services.AddDbContext<MedicalCenterDBContext>(
    options => options.UseMySql(dbConnectionString, serverVersion)
);


// Dependency injection

builder.Services.AddTransient<IPatientSevice, PatientService>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();

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
