//Sauraav Jayrajh
//ST100024620
using Microsoft.EntityFrameworkCore;
using Sauraav_POE_CLDV.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ConnectDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AzureLogin")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ConnectDB>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseDatabaseErrorPage();

app.UseHttpsRedirection();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseDefaultFiles();

app.UseRouting();

app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

