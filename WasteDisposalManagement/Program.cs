using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WasteDisposalManagement.Models;

var builder = WebApplication.CreateBuilder(args);

//configure database connection with connection string specified on appsettings.json
builder.Services.AddDbContext<WasteManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnectionString' not found.")));


//extend identity on existing user class and dbcontext
builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WasteManagementDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

//add policies, roles and permissions to project
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("readpolicy", builder => builder.RequireRole("Admin", "Staff", "Customer"));
    options.AddPolicy("writepolicy", builder => builder.RequireRole("Admin", "Staff", "Customer"));
});
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
app.MapRazorPages();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
