using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Managers;
using BusinessLogicLevel.Mapper;
using DataAccessLevel.Interfaces;
using DataAccessLevel.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace TaskPlanner
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestApi", Version = "v1" });
            });

            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IWorkProcessRepository, WorkProcessRepository>();
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            })));
            services.AddSingleton<ITaskManager, TaskManager>();
            services.AddSingleton<IEmployeeManager, EmployeeManager>();

            services.AddMvc();
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApi v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
