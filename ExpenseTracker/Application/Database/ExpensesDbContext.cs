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
        entityBuilder.Property(x => x.Description).HasMaxLength(200);
    }
}

//dotnet ef migrations add InitialCreate --verbose --project Application --startup-project WebApi