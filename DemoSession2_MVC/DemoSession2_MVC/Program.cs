using DemoSession2_MVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DemoService, DemoServiceImpl>();

builder.Services.AddScoped<CalculateService, CalculateServiceImpl>();

builder.Services.AddScoped<HCNService, HCNServiceImpl>();

var app = builder.Build();

app.UseStaticFiles();

//https://localhost:5019/controller/action/param1/param2/....

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

//app.MapGet("/", () => "Hello World!");

app.Run();
