using Microsoft.EntityFrameworkCore;
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
using TaskTracker.Application.Common.Notifications;
using TaskTracker.Application.Common.Logger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => { options.UseMemberCasing(); });
builder.Services.AddSwaggerGen();
var taskTrackerDbContexOptionsBuilder = new DbContextOptionsBuilder<TaskTrackerDbContext>().UseSqlServer(builder.Configuration.GetConnectionString(nameof(TaskTrackerDbContext)));
builder.Services.AddTransient<IFactory<TaskTrackerDbContext>>(x => new DelegatingFactory<TaskTrackerDbContext>(() => new TaskTrackerDbContext(taskTrackerDbContexOptionsBuilder.Options, builder.Configuration)));
builder.Services.AddTransient<IRepository<ProjectEntity>, EfRepository<ProjectEntity>>();
builder.Services.AddTransient<IRepository<TaskEntity>, EfRepository<TaskEntity>>();
builder.Services.AddTransient<TaskTracker.Domain.Contracts.ILogger, DefaultLogger>();
builder.Services.AddTransient<SimpleLogger.ILogger, SimpleLogger.Logger>();
builder.Services.AddTransient<SimpleLogger.IOutput>(provider => new SimpleLogger.FileOutput($"{Environment.CurrentDirectory}\\log.txt"));
builder.Services.AddToastify(config => { config.DurationInSeconds = 5; config.Position = Position.Right; config.Gravity = Gravity.Bottom; });
builder.Services.AddTransient<TaskTracker.Domain.Contracts.INotification, ToastifyNotification>();
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperConfiguration>();
});
builder.Services.AddTransient(x => autoMapperConfig.CreateMapper());
builder.Services.AddTransient<TaskTracker.Domain.Contracts.IMapper, SimpleMapper>();
System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains(nameof(TaskTracker))).ToArray();
builder.Services.AddMediatR(assemblies);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}");
app.Run();