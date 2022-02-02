using System;
using System.Text;
using Battleship.API.Core.Contracts.Repositories;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Contracts.UnitsOfWork;
using Battleship.API.Core.Services;
using Battleship.API.Infrastructure.Repositories;
using Battleship.API.Infrastructure.UnitsOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Battleship.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IHashService, HashService>();
            services.AddTransient<IChallengeService, ChallengeService>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IChallengesRepository, ChallengesRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Battleship API", Version = "v1" });
                options.EnableAnnotations();
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
                    };
                });
        }
    }
}

