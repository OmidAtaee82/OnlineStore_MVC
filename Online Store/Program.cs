using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using ServicesContract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OmidOnlineStoreDB>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<OmidOnlineStoreDB>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
