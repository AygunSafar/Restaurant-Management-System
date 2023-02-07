using ManagementSystem.Helper;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<HasAdmin> HasAdmins { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HasAdmin>().HasData(new HasAdmin { Id = 1, HasAdmins = false });
            builder.Entity<Kassa>().HasData(new Kassa { Id = 1, LastModifiedTime = System.DateTime.UtcNow.AddHours(4), LastModifiedPerson = "-",LastModifiedCause="-", LastAmount = 0, Balance = 0, });

        }

      
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Kassa> Kassas { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }





    }
}
