using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Extensions;
using WebAPI.Helpers;
using WebAPI.Interfaces;
using WebAPI.services;

namespace WebAPI
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            services.AddScoped<IPhotoService, PhotoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Housing API");
            });

            app.ConfigureExceptionHandler(); //implemented in Extentions folder to handle global exceptions
     
            app.UseRouting();
            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseCors( m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
