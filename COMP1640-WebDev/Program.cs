using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


//1. Add role to account
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var user1 = await userManager.FindByEmailAsync("guest@local.com");
    var user2 = await userManager.FindByEmailAsync("admin@admin.com");
    var user3 = await userManager.FindByEmailAsync("mm@gmail.com");
    var user4 = await userManager.FindByEmailAsync("mc@gmail.com");
    var user5 = await userManager.FindByEmailAsync("student1@student.com");

    if((user1 != null))
    {
        await userManager.AddToRoleAsync(user1, "Guest");
        await userManager.AddToRoleAsync(user2, "Admin");
        await userManager.AddToRoleAsync(user3, "Marketing Manager");
        await userManager.AddToRoleAsync(user4, "Marketing Coordinator");
        await userManager.AddToRoleAsync(user5, "Student");

    }
}

app.Run();
