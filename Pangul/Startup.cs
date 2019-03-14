using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pangul.EntityFramework;
using Pangul.Services;
using System.Collections.Generic;
using System.IO;

namespace Pangul
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

            InitilizeDatabase();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            AddCustomServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void AddCustomServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(GetConnectionString()));
            services.Configure<List<string>>(_configuration.GetSection("sites"));
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            services.AddScoped<IHealthChecker, HealthChecker>();
            services.AddScoped<IHealthJob, HealthJob>();
            services.AddScoped<IUrlService, UrlService>();
        }

        private void InitilizeDatabase()
        {
            var connection = new SqliteConnection(GetConnectionString());
            connection.Open();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(connection)
                    .Options;

            using (var client = new DatabaseContext(options))
            {
                client.Database.EnsureCreated();
            }
        }

        private string GetConnectionString()
        {
            var path = Path.Combine(_hostingEnvironment.ContentRootPath, "database.db");

            return $"Data Source={path}";
        }
    }
}
