using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskTracker.Contracts.Contracts;
using TaskTracker.Contracts.DataTypes;
using TaskTracker.Core;
using TaskTracker.Storage.Data;
using TaskTracker.Host.Common;

namespace TaskTracker.Host
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
            services.AddControllersWithViews();

            services.AddSwaggerGen();

            var taskTrackerDbContexOptionsBuilder = new DbContextOptionsBuilder<TaskTrackerDbContext>().UseSqlServer(Configuration.GetConnectionString(nameof(TaskTrackerDbContext)));
                       
            services.AddTransient<IFactory<TaskTrackerDbContext>>(x => new DelegatingFactory<TaskTrackerDbContext>(() => new TaskTrackerDbContext(taskTrackerDbContexOptionsBuilder.Options)));

            services.AddTransient<IRepository<Project>, EfRepository<Project>>();

            services.AddTransient<IRepository<Project>, EfRepository<Project>>();

            services.AddTransient<IRepository<Task>, EfRepository<Task>>();

            services.AddToastify(config => { config.DurationInSeconds = 5; config.Position = Position.Right; config.Gravity = Gravity.Bottom; });

            services.AddTransient<INotification, ToastifyNotification>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
