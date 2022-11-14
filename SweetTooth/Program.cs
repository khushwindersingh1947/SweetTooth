using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config  = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//requireConfirmedAccount=true means when user registers they need to authenticate by clicking
//a link in an email

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
    .AddGoogle(options => {
        //AccessViolationException Google Aith Section Of AppSettings .json
        IConfigurationSection googleAuthNSection = config.GetSection("Authentication:Google");

        // read google API key values from config section and set as options
        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];

    }).AddFacebook(options => {

        //AccessViolationException Google Aith Section Of AppSettings .json
        IConfigurationSection facebookAuthNSection = config.GetSection("Authentication:Facebook");

        // read google API key values from config section and set as options
        options.ClientId = facebookAuthNSection["ClientId"];
        options.ClientSecret = facebookAuthNSection["ClientSecret"];

    });

builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
