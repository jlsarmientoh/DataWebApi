using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Javeriana.Pica.Core.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SchoolAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization();
            services.AddDbContext<SchoolContext>(options =>
                options.UseInMemoryDatabase("School"));
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization();
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:SchoolConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
