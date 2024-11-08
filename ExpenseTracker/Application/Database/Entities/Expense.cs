namespace Application.Database.Entities;

public class Expense
{
    public Guid Id { get; init; }
    public int Amount { get; init; }
    public ExpenseCategory Category { get; init; }
    public DateTime Date { get; init; }
    public string Description { get; init; } = string.Empty;
}

public enum ExpenseCategory
{
    Food,
    Transportation,
    Utilities,
    Entertainment,
    Other
}