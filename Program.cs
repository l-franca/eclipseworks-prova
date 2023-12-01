using eclipseworks_teste.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var services = builder.Services;
var config = builder.Configuration;
var db = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? config.GetConnectionString("pgsql");
var options = new DbContextOptionsBuilder<EclipseContext>();

services.AddDbContextPool<EclipseContext>(opt => opt.UseNpgsql(db).EnableDetailedErrors());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();