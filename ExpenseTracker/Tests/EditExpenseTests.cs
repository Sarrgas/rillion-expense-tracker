using Application.Database;
using Application.Database.Entities;
using Application.Features;
using FluentAssertions;
using Tests.Common;


namespace Tests;

public class EditExpenseTests
{
    private EditExpense.Handler _sut;
    private ExpensesDbContext _context;

    [SetUp]
    public void Setup()
    {
        _context = SqliteInMemoryDb.GetContext();
        _sut = new EditExpense.Handler(_context);
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
    
    [Test]
    public async Task GivenOneExpenseExist_WhenEditingCategory_ThenExpenseHasNewCategory()
    {
        var existingExpense = new Expense
        {
            Id = default,
            Amount = 149,
            Category = ExpenseCategory.Other,
            Date = new DateTime(2020, 01, 01),
            Description = "Netflix"
        };
        _context.Expenses.Add(existingExpense);
        await _context.SaveChangesAsync();
        
        await _sut.Handle(new EditExpense.Request(existingExpense.Id, new EditableExpense(existingExpense.Amount, ExpenseCategory.Entertainment)), CancellationToken.None);
        
        var updatedExpense = await _context.Expenses.FindAsync(existingExpense.Id);
        updatedExpense.Category.Should().Be(ExpenseCategory.Entertainment);
    }
    
    [Test]
    public async Task GivenOneExpenseExist_WhenEditingAmount_ThenExpenseHasNewAmount()
    {
        var existingExpense = new Expense
        {
            Id = default,
            Amount = 149,
            Category = ExpenseCategory.Other,
            Date = new DateTime(2020, 01, 01),
            Description = "Netflix"
        };
        _context.Expenses.Add(existingExpense);
        await _context.SaveChangesAsync();
        
        await _sut.Handle(new EditExpense.Request(existingExpense.Id, new EditableExpense(99, existingExpense.Category)), CancellationToken.None);
        
        var updatedExpense = await _context.Expenses.FindAsync(existingExpense.Id);
        updatedExpense.Amount.Should().Be(99);
    }
}