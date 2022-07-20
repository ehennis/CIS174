using CIS174Library.Data;
using CIS174Library.Models;
using CIS174Library.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MUST BE CALLED before AddControllersWithViews
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<LibraryContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryContext")));

// Add Libraries
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

// Fake code for demo!
builder.Services.AddScoped<IBook, Book>(sp =>
{
    return new Book() { BookId = 50, Name = "Dependency Injected!", Year = 2022 };

});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<LibraryContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// MUST BE CALLED before UseEndpoints
app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "Static",
    pattern: "{controller=Home}/{action}/Page/{num}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
