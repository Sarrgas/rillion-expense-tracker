namespace Application.Database.Entities;

public class Expense
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public ExpenseCategory Category { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
}

public enum ExpenseCategory
{
    Food,
    Transportation,
    Utilities,
    Entertainment,
    Other
}