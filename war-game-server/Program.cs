using Microsoft.EntityFrameworkCore;
using war_game_server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conStr = "WarDbContext";

builder.Services.AddControllers();
builder.Services.AddDbContext<WarDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString(conStr)));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
