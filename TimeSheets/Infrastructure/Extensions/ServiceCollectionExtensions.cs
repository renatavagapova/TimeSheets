﻿using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using TimeSheets.Data.Ef;
using TimeSheets.Data.Implementation;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Implementation;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Infrastructure.Validation;
using TimeSheets.Models.Dto;
using TimeSheets.Models.Dto.Authentication;

namespace TimeSheets.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TimesheetDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Timesheets"));
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));
            services.Configure<JwtRefreshOptions>(configuration.GetSection("Authentication:JwtRefreshOptions"));
            var jwtSettings = new JwtOptions();
            configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

            services.AddTransient<ILoginManager, LoginManager>();

            services
                .AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
                });
        }

        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<ISheetManager, SheetManager>();
            services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IRefreshTokenManager, RefreshTokenManager>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISheetRepo, SheetRepo>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRefreshTokenRepo, RefreshTokenRepo>();
            services.AddScoped<IRefreshTokenRepo, RefreshTokenRepo>();
        }

        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Timesheets", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SheetRequest>, SheetRequestValidator>();
        }
    }
}
