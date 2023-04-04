
using Business.BusinessLogic.Impl;
using Business.BusinessLogic.Interface;
using Business.BusinessRepository.Context;
using Business.BusinessRepository.Impl;
using Business.BusinessRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddDbContext<Business.BusinessRepository.Context.DbContext>(options =>
                        options.UseSqlServer(Configuration["ConnectionString"])
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            _ = services.AddTransient<IStudentService, StudentService>();
            _ = services.AddTransient<IStudentRepository, StudentRepository>();
            _ = services.AddTransient<ICourseService, CourseService>();
            _ = services.AddTransient<ICourseRepository, CourseRepository>();
            _ = services.AddTransient<ICourseStudentRepository, CourseStudentRepository>();
            _ = services.AddTransient<IEvaluationService, EvaluationService>();
            _ = services.AddTransient<IEvaluationRepository, EvaluationRepository>();

            _ = services.AddControllers();
            _ = services.AddSwaggerGen();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(option => {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }

    }
}
