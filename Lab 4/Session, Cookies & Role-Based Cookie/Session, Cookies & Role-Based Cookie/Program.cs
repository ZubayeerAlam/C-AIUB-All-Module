using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers and views 
builder.Services.AddControllersWithViews();

// 1. Register Session services 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 2. Register Built-in Cookie Authentication 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";              // Redirect if unauthenticated 
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if role unauthorized 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

// 3. Register Authorization services 
builder.Services.AddAuthorization(); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 1. Session Middleware 
app.UseSession();

// 2. Authentication Middleware (Identifies WHO the user is) 
app.UseAuthentication();

// 3. Authorization Middleware (Verifies WHAT roles/access the user has) 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();