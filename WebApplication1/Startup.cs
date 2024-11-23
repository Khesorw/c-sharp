using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace WebApplication1
{
    public class startup
    {

        private readonly IConfiguration configuration;

        public startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
           
            services.AddDbContext<BlogDataContext>(options => {

                var connectionString = configuration.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectionString);

            });
           services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env) {
        
        
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }


            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid")) { throw new Exception("Exception happend"); }

                await next();
            });

           

            app.UseRouting();

            app.UseEndpoints(endpoint => {


                endpoint.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{Id?}");
            });
         




        }



    }
}
