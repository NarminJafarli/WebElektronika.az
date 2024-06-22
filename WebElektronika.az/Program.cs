using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebElektronika.az.Business.Abstract;
using WebElektronika.az.Business.Concrete;
using WebElektronika.az.Business.Config;
using WebElektronika.az.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AppDbContext

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

//AutoMapper

var mappingconfig= new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

builder.Services.AddSingleton(mappingconfig.CreateMapper());


//Services

builder.Services.AddScoped<ITechnologyServices, TechnologyService>();


object mappingConfig(IServiceProvider provider)
{
    throw new NotImplementedException();
}

Profile MapperProfile()
{
    throw new NotImplementedException();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
