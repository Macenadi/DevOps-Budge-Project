using Budget.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    Type = TransactionType.Income,
                    Amount = 5000,
                    Category = "Salary",
                    Description = "Monthly salary",
                    Date = new DateTime(2026, 3, 1),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 2,
                    Type = TransactionType.Expense,
                    Amount = 120,
                    Category = "Food",
                    Description = "Groceries",
                    Date = new DateTime(2026, 3, 2),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 3,
                    Type = TransactionType.Expense,
                    Amount = 60,
                    Category = "Transport",
                    Description = "Gas",
                    Date = new DateTime(2026, 3, 3),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 4,
                    Type = TransactionType.Expense,
                    Amount = 800,
                    Category = "Housing",
                    Description = "Rent",
                    Date = new DateTime(2026, 3, 1),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 5,
                    Type = TransactionType.Income,
                    Amount = 500,
                    Category = "Freelance",
                    Description = "Design project",
                    Date = new DateTime(2026, 3, 5),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 6,
                    Type = TransactionType.Expense,
                    Amount = 45,
                    Category = "Entertainment",
                    Description = "Movie tickets",
                    Date = new DateTime(2026, 3, 6),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 7,
                    Type = TransactionType.Expense,
                    Amount = 200,
                    Category = "Shopping",
                    Description = "Clothes",
                    Date = new DateTime(2026, 3, 4),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 8,
                    Type = TransactionType.Expense,
                    Amount = 90,
                    Category = "Health",
                    Description = "Pharmacy",
                    Date = new DateTime(2026, 3, 7),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 9,
                    Type = TransactionType.Expense,
                    Amount = 150,
                    Category = "Education",
                    Description = "Online course",
                    Date = new DateTime(2026, 3, 8),
                    UserId = "demo"
                },
                new Transaction
                {
                    Id = 10,
                    Type = TransactionType.Expense,
                    Amount = 35,
                    Category = "Food",
                    Description = "Restaurant",
                    Date = new DateTime(2026, 3, 9),
                    UserId = "demo"
                }
            );
        }
    }
}