using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Project_server
{
    //ginrut
    //Scaffold-DbContext "Server=srv2\pupils;Database=GeneralDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
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
           
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            services.AddScoped<IExerciseDL, ExerciseDL>();
            services.AddScoped<ILessonDL, LessonDL>();
            services.AddScoped<IMessageDL, MessageDL>();
            services.AddScoped<IPatientDL, PatientDL>();
            services.AddScoped<ISpeechTherapistDL, SpeechTherapistDL>();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IWordDL, WordDL>();

            services.AddScoped<IExerciseBL, ExerciseBL>();
            services.AddScoped<ILessonBL, LessonBL>();
            services.AddScoped<IMessageBL, MessageBL>();
            services.AddScoped<IPatientBL, PatientBL>();
            services.AddScoped<ISpeechTherapistBL, SpeechTherapistBL>();
            services.AddScoped<IUserBL, UserBL>();
          
            services.AddScoped<IWordBL, WordBL>();
            services.AddScoped<IRatingBL, RatingBL>();
            services.AddScoped<IRatingDL, RatingDL>();

            services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();

            services.AddDbContext<GeneralDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("nechami")));
            services.AddResponseCaching();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project_server", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("server up!");
            //app.UseErrorMiddleware();
            if (env.IsDevelopment())
            {
              //  app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project_server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

  
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });


            app.Map("/api",a=> {
                
                    a.UseRouting();
                    a.UseRatingMiddleware();
                  
                    a.UseAuthorization();
                    a.UseEndpoints(endpoints =>
                     {
                         endpoints.MapControllers();
                     });
                
               
                
            });//.HasValue("API")
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
