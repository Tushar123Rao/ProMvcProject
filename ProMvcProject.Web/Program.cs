using Microsoft.EntityFrameworkCore;
using ProMvcProject.Domain.Interfaces;
using ProMvcProject.Infrastructure.Data;
using ProMvcProject.Infrastructure.Repositories;
using ProMvcProject.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. DATABASE CONNECTION
// This reads the connection string we just put in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. DEPENDENCY INJECTION (The "Glue")
// We tell the app: "Whenever someone asks for the Interface, give them this Implementation"
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// 3. ADD MVC SUPPORT
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 4. CONFIGURE THE HTTP PIPELINE (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // For CSS/JS in wwwroot

app.UseRouting();

app.UseAuthorization();

// 5. DEFINE ROUTES (How URLs find Controllers)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
