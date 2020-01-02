using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Votings.Server.BusinessLayer.Services.Implementations;
using Votings.Server.BusinessLayer.Services.Interfaces;
using Votings.Server.DAL;
using Votings.Server.DAL.Models;
using Votings.Server.Helpers;
using Microsoft.OpenApi.Models;
using System;

namespace Votings.Server
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseProvider(Configuration, Environment);
            services.AddIdentity();
            services.AddCompression();
            services.AddAuthentication(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().AddNewtonsoftJson();

            services.AddTransient<IEmailSendingService, FromMockeeMockersEmailSendingService>();
            services.AddTransient
                <IFileSavingService, FileSavingService>
                (p => new FileSavingService(Environment.WebRootPath));

            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();
            services.AddScoped<IEditProfileService, EditProfileService>();
            services.AddScoped<IVotingsService, VotingsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<User> um, RoleManager<IdentityRole> rm)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            if (Configuration.GetDatabaseType() == DatabaseType.InMemory)
            {
                StartupHelper.EnsureDatabaseCreated<VotingsDbContext>(app.ApplicationServices);
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });

            if (env.IsDevelopment())
            {
                IdentityDataInitializer.SeedData(um, rm);
            }
        }

    }
}
