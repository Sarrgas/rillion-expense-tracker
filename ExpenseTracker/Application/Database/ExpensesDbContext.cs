using Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Database;

public class ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var expenseBuilder = modelBuilder.Entity<Expense>();
        expenseBuilder.Property(x => x.Description).HasMaxLength(200);
        
        var userBuilder = modelBuilder.Entity<User>();
        userBuilder.HasKey(x => x.Id);
        userBuilder.Property(x => x.Username).HasMaxLength(50);
        userBuilder.Property(x => x.Password).HasMaxLength(50);
    }
}
