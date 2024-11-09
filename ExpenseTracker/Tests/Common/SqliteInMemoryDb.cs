using System.Data.Common;
using Application.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tests.Common;

public static class SqliteInMemoryDb
{
    public static ExpensesDbContext GetContext()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();

        var contextOptions = new DbContextOptionsBuilder<ExpensesDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new ExpensesDbContext(contextOptions);
        context.Database.EnsureCreated();

        return context;
    }
}