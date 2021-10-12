using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using AspNetCoreHero.ToastNotification;
using TaskTracker.Infrastructure.EFCore.Data;
using TaskTracker.Infrastructure.Services;
using TaskTracker.Application.Common;
using AutoMapper;
using TaskTracker.Application.Common.Mapper.Configurations;
using TaskTracker.Application.Common.Mapper;
using MediatR;
using System;
using System.Linq;
using TaskTracker.Application.Common.Notifications;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Domain.DataTypes;
using TaskTracker.Application.Core.Projects.Queries;
using System.Collections.Generic;
using TaskTracker.Application.Core.Tasks.Commands;

namespace TaskTracker.Web
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
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               {
                   options.UseMemberCasing();
               });

            services.AddSwaggerGen();

            var taskTrackerDbContexOptionsBuilder = new DbContextOptionsBuilder<TaskTrackerDbContext>().UseSqlServer(Configuration.GetConnectionString(nameof(TaskTrackerDbContext)));
                       
            services.AddTransient<IFactory<TaskTrackerDbContext>>(x => new DelegatingFactory<TaskTrackerDbContext>(() => new TaskTrackerDbContext(taskTrackerDbContexOptionsBuilder.Options)));

            services.AddTransient<IRepository<ProjectEntity>, EfRepository<ProjectEntity>>();

            services.AddTransient<IRepository<TaskEntity>, EfRepository<TaskEntity>>();

            services.AddToastify(config => { config.DurationInSeconds = 5; config.Position = Position.Right; config.Gravity = Gravity.Bottom; });

            services.AddTransient<Domain.Contracts.INotification, ToastifyNotification>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfiguration>();
            });

            services.AddTransient(x => autoMapperConfig.CreateMapper());

            services.AddTransient<Domain.Contracts.IMapper, SimpleMapper>();

            System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains(nameof(TaskTracker))).ToArray();
            services.AddMediatR(assemblies);

            var types = new List<(Type, Type, Type)> {
                (typeof(ProjectViewModel), typeof(ProjectEntity), typeof(VoidType)) ,
                (typeof(TaskViewModel), typeof(TaskEntity), typeof(VoidType)) ,
            };

            RegisterHandlers(services, types);
        }

        private void RegisterHandlers(IServiceCollection services, List<(Type viewModel, Type entity, Type result)> types)
        {
            //duplicate
            services.AddTransient<IRequestHandler<CreateBaseCommand<ProjectViewModel, VoidType>, VoidType>, CreateProjectCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBaseCommand<ProjectViewModel, VoidType>, VoidType>, UpdateProjectCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteBaseCommand<VoidType>, VoidType>, DeleteProjectCommandHandler>();
            services.AddTransient<IRequestHandler<GetBaseQuery<ProjectViewModel>, ProjectViewModel>, GetProjectQueryHandler>();
            services.AddTransient<IRequestHandler<GetBasesQuery<ProjectViewModel>, List<ProjectViewModel>>, GetProjectsQueryHandler>();

            services.AddTransient<IRequestHandler<CreateBaseCommand<TaskViewModel, VoidType>, VoidType>, CreateTaskCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBaseCommand<TaskViewModel, VoidType>, VoidType>, UpdateTaskCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteBaseCommand<VoidType>, VoidType>, DeleteTaskCommandHandler>();
            services.AddTransient<IRequestHandler<GetBaseQuery<TaskViewModel>, TaskViewModel>, GetTaskQueryHandler>();
            services.AddTransient<IRequestHandler<GetBasesQuery<TaskViewModel>, List<TaskViewModel>>, GetTasksQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();                      
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Projects}/{action=Index}/");
            });
        }
    }
}
