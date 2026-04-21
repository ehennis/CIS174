using Microsoft.EntityFrameworkCore;
using CIS174Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CIS174Library.Data
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "Core MVC",
                    Year = 2022
                },
                new Book
                {
                    BookId = 2,
                    Name = "The C++ Programming Language",
                    Year = 2000
                });
        }


        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            using (var scoped = serviceProvider.CreateScope())
            {
                UserManager<User> userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string username = "admin";
                string pwd = "admin";
                string roleName = "Admin";

                // if role doesn't exist, create it
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }

                if (await userManager.FindByNameAsync(username) == null)
                {
                    User user = new User() { UserName = username };
                    var result = await userManager.CreateAsync(user, pwd);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
        }
    }
}
