using Application.Extensions;
using Application.Students.Handlers.Querys;
using Application.Students.Models;
using Application.Students.Querys;
using Domain.Students.Repositories;
using Infrastructure.Extensions;
using Infrastructure.Students.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Ioc
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddControllers();

            services.AddSwaggerGen();

           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddInfrastructureConfiguration();
            services.AddApplicationConfiguration();

            services.AddAutoMapper(typeof(Program).Assembly);
            //services.AddScoped<IStudentRepository, StudentRepository>();
            //services.AddScoped<IRequestHandler<GetStudentsQuery, IEnumerable<Student>>, GetStudentsQueryHandler>();
        }


        // Middleware 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
