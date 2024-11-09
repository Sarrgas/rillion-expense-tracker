namespace Application.Database.Entities;

public class Expense
{
    public Guid Id { get; init; }
    public int Amount { get; set; }
    public ExpenseCategory Category { get; set; }
    public DateTime Date { get; init; }
    public string Description { get; init; } = string.Empty;
    public int UserId { get; set; }
}

public enum ExpenseCategory
{
    Food,
    Transportation,
    Utilities,
    Entertainment,
    Other
}