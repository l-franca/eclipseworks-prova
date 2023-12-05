using eclipseworks_teste.Context;
using eclipseworks_teste.Repositories;
using eclipseworks_teste.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var services = builder.Services;
var config = builder.Configuration;
var db = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? config.GetConnectionString("pgsql");

services.AddDbContextPool<EclipseContext>(opt => opt.UseNpgsql(db).EnableDetailedErrors());
services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
}));

services.AddControllers();

services.AddTransient<EclipseContext, EclipseContext>();

services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
services.AddSingleton<ITarefaRepository, TarefaRepository>();
services.AddSingleton<IProjetoRepository, ProjetoRepository>();
services.AddSingleton<IHistoricoTarefaRepository, HistoricoTarefaRepository>();

services.AddSingleton<IUsuarioService, UsuarioService>();
services.AddSingleton<ITarefaService, TarefaService>();
services.AddSingleton<IProjetoService, ProjetoService>();
services.AddSingleton<IHistoricoTarefaService, HistoricoTarefaService>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


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

using (var scope = app.Services.CreateScope())
{
    var sv = scope.ServiceProvider;

    var context = sv.GetRequiredService<EclipseContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();