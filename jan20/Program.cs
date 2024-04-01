using jan20.Common;
using jan20.Services;
using jan20.Services.Iservices;
using Jan20.data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
	options.Cookie.Name = ".AdventureWorks.Session";
	options.IdleTimeout = TimeSpan.FromMinutes(10);
	options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<Mysession>();



builder.Services.AddDbContext<AppDb>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IItemService,ItemService>();

builder.Services.AddTransient<IimageService, ItemImages>();

builder.Services.AddTransient<IReg,RegService>();

builder.Services.AddTransient<IloginService, LoginService>();
builder.Services.AddTransient<ICart, CartService>();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((option =>
{

    option.LoginPath = "/login/login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
}));

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy => policy.RequireRole("Admin","User"));
    option.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});




// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

