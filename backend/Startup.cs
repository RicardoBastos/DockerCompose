using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
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


            // var host = Configuration["DBHOST"] ?? "172.18.0.2";
            // var db = Configuration["DBNAME"] ?? "Teste";
            // var port = Configuration["DBPORT"] ?? "1401";
            // var username = Configuration["DBUSERNAME"] ?? "sa";
            // var password = Configuration["DBPASSWORD"] ?? "Ricardo@123";

            // string connStr = $"Data Source={host},{port};Integrated Security=False;";
            // connStr += $"User ID={username};Password={password};Database={db};";
            // connStr += $"Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";




              services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                //options.UseSqlServer(connStr));

              //DbInitializer.Initialize(context);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  Contexto db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

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
