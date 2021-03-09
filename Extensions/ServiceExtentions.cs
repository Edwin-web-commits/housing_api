using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Errors;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            
                //override default exception handler
                app.UseExceptionHandler(error =>
                {
                    error.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (contextFeature != null) //when there is Error in the controller(context)
                        {
                            Log.Error($"Something Went Wrong In The {contextFeature.Error}");

                            //generate an error model with the statusCode and the Message
                            await context.Response.WriteAsync(new ApiError
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error. Please Try Again Later."
                            }.ToString());
                        }
                    });
                });
           
        }

        //configure Identity core framework

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }

        //configure JWT
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var key = Environment.GetEnvironmentVariable("MYKEY");

            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

                };
            });
        }
    }
}
