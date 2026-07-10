using Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OmidOnlineStoreDB>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});
var app = builder.Build();
app.MapControllers();
app.UseStaticFiles();

app.Run();
