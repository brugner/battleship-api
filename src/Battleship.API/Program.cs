using System.Text;
using Battleship.API.Core.Contracts.Repositories;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Contracts.UnitsOfWork;
using Battleship.API.Core.Services;
using Battleship.API.Core.Settings;
using Battleship.API.Extensions;
using Battleship.API.Infrastructure.DbContexts;
using Battleship.API.Infrastructure.Repositories;
using Battleship.API.Infrastructure.UnitsOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwagger();

builder.Services.AddDbContext<BattleshipDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddAppServices();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-dev");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
