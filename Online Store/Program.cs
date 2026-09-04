using Entity;
using Microsoft.EntityFrameworkCore;
using Services;
using ServicesContract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OmidOnlineStoreDB>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
var app = builder.Build();
app.MapControllers();
app.UseStaticFiles();

app.Run();
