using Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Database;

public class ExpensesDbContext : DbContext
{
    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
    {
    }
    
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityBuilder = modelBuilder.Entity<Expense>();
        // entityBuilder.HasKey()
        entityBuilder.Property(x => x.Description).HasMaxLength(200);
    }
}