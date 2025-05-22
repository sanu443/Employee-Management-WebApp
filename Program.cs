using Microsoft.EntityFrameworkCore;
using PrimarieApp.Data;
using PrimarieApp.Repositories;
using PrimarieApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//conectare la postgre
builder.Services.AddDbContext<PrimarieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PrimarieContext")));

builder.Services.AddScoped<IDepartamentRepository, DepartamentRepository>();
builder.Services.AddScoped<IDepartamentService, DepartamentService>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<IAngajatRepository, AngajatRepository>();
builder.Services.AddScoped<IAngajatService, AngajatService>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
