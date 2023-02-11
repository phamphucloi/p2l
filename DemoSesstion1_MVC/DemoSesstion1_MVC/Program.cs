var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

//https://localhost:5019/controller/action/param1/param2/....

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Demo}/{action=Index3}");

//app.MapGet("/", () => "Hello World!");

app.Run();
