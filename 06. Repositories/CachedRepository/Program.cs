namespace CachedRepository
{
    using System;

    using CachedRepository.Data;
    using CachedRepository.Data.Models;
    using CachedRepository.Infrastructure.Extensions;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        private static string dbConnectionString = string.Empty;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureConfiguration(builder.Configuration);
            ConfigureServices(builder.Services, builder.Environment);

            var app = builder.Build();

            ConfigureMiddleware(app, app.Environment);
            ConfigureEndpoints(app);

            app.Run();
        }

        private static void ConfigureConfiguration(IConfiguration configuration)
        {
            dbConnectionString = configuration.GetConnectionString("DefaultConnection") 
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        private static void ConfigureServices(IServiceCollection services, IHostEnvironment env)
        {
            services
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(
                        dbConnectionString,
                        sqlOptions => sqlOptions.EnableRetryOnFailure()
                    ))
                .AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            if (env.IsDevelopment())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }

            services.AddRazorPages();
        }

        private static void ConfigureMiddleware(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                app.UseMigrations();
                app.SeedDatabase();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
        }

        private static void ConfigureEndpoints(IEndpointRouteBuilder app)
        {
            app.MapRazorPages();
        }
    }
}
