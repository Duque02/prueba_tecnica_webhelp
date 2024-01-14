using Webhelp.PruebaTecnica.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
