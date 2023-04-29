using Microsoft.AspNetCore.Authentication.Cookies;
using TaskTracker.BLL;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL;
using TaskTracker.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("TaskTrackerConnectStr");
builder.Services.AddSingleton(connectionString);
builder.Services.AddScoped<ITaskTrackerLogic, TaskTrackerLogic>();
builder.Services.AddSingleton<ITaskTrackerDAO>(provider => new TaskTrackerDAO(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => //CookieAuthenticationOptions
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
        options.ExpireTimeSpan = new TimeSpan(7, 0, 0, 0);

    });
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Auth}/{action=Login}/{id?}");
});


app.Run();
