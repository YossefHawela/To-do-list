using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ToDoList.Data.DataConnector>(); // Register DataConnector as a singleton service
builder.Services.AddSingleton<ToDoList.Data.UIDataSorage>(); // Register DataConnector as a singleton service

builder.Services.AddAuthentication("ToDoAuthenCookie")
    .AddCookie("ToDoAuthenCookie", options =>
    {
        options.LoginPath = "/Account/Login"; // Set the login path
        options.AccessDeniedPath = "/Account/AccessDenied"; // Set the access denied path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set the cookie expiration time
        options.SlidingExpiration = true; // Enable sliding expiration
        options.LogoutPath = "/Account/Logout"; // Set the logout path
        options.ReturnUrlParameter = "returnUrl"; // Set the return URL parameter name
    });


builder.Services.AddDbContext<ToDoDataContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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

app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
