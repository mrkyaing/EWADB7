var builder = WebApplication.CreateBuilder(args);
//adding(register) the controllers and views to know as routes
builder.Services.AddControllersWithViews();
var app = builder.Build();
/*
//localhost:7000
app.MapGet("/", () => "Hello World!");
//localhost:7000/sayhello
app.MapGet("/sayHello", () => "Hi,I am fine.");//url mapping for routing
app.MapGet("/time/now", () => "Today is " + DateTime.Now);
app.MapGet("/time/yestarday", () => "Yestarday is " + DateTime.Now.AddDays(-1).ToString("dddd"));
*/
//declare to use contents file in wwwroot folders
app.UseStaticFiles();
app.MapControllerRoute(name: "Default", pattern: "{controller=home}/{action=friends}/{id?}");
//Maps all of the routes defined in Controllers
app.MapDefaultControllerRoute();
app.Run();
