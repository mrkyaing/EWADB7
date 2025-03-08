using HRMS.Web.DAO;
using HRMS.Web.Services;
using HRMS.Web.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
//get the configuration from appsetting.json
var config = builder.Configuration;
//register the DbContext to connect to the database
builder.Services.AddDbContext<HRMSWebDbContext>(o => o.UseSqlServer(config.GetConnectionString("HRMSDB")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//depedency injection for all of domains
builder.Services.AddTransient<IPositionService, PositionService>();
//builder.Services.AddTransient<ID, PositionService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();// to access all file under wwwroot folder 
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
