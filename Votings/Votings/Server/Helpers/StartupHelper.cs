using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Votings.Server.Helpers;
using System;
using System.Linq;
using System.Text;
using Votings.Server.DAL;
using Votings.Server.DAL.Models;

namespace Votings.Server.Helpers
{
    public static class StartupHelper
    {        
        public static void EnsureDatabaseCreated<TContext>(IServiceProvider serviceProvider) where TContext : DbContext
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetService<TContext>();
            context.Database.EnsureCreated();
        }

        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidateAudience = true,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        ValidIssuer = configuration["JwtIssuer"],
                                        ValidAudience = configuration["JwtAudience"],
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]))
                                    };
                                });
        }

        public static void AddCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<VotingsDbContext>()
              .AddDefaultTokenProviders();
        }

        public static void AddDatabaseProvider(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var databaseType = configuration.GetDatabaseType();

            if (databaseType == DatabaseType.InMemory)
            {
                services.AddDbContext<VotingsDbContext>(
                    options => options
                     .UseLazyLoadingProxies()
                     .UseInMemoryDatabase("random_name"));
            }
            if (databaseType == DatabaseType.SQLSERVER)
            {
                var connStr = configuration.GetConnectionString(databaseType, env.IsDevelopment());

                services.AddDbContext<VotingsDbContext>(
                    options => options
                    .UseSqlServer(connStr, b => b.MigrationsAssembly("Votings.Server.DAL"))
                    );
            }
        }

        public static string GetConnectionString(this IConfiguration configuration, DatabaseType type, bool isDev)
        {
            string dbName;
            var ctxName = 
                nameof(VotingsDbContext)
                .Remove(
                    nameof(VotingsDbContext).IndexOf("context", StringComparison.InvariantCultureIgnoreCase), 
                    "context".Length
                    );

            if (isDev)
            {
                dbName = $"{(int)type}_{ctxName}_Local";
            }
            else
            {
                dbName = $"{(int)type}_{ctxName}";
            }

            return configuration.GetConnectionString(dbName);
        }
    }
}
