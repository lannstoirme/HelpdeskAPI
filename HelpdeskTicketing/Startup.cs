using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HelpdeskTicketing.Controllers;
using HelpdeskTicketing.Services;
using HelpdeskTicketing.Models;
using Microsoft.Extensions.Options;

namespace HelpdeskTicketing
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
            services.Configure<HelpdeskDatabaseSettings>(
                Configuration.GetSection(nameof(HelpdeskDatabaseSettings)));

            services.AddSingleton<IHelpdeskDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<HelpdeskDatabaseSettings>>().Value);

            services.AddSingleton<UserService>();

            services.AddSingleton<MessageService>();

            services.AddSingleton<DepartmentService>();

            services.AddSingleton<OutcomeService>();

            services.AddControllers();
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
