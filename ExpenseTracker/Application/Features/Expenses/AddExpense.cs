using Application.Database;
using Application.Database.Entities;
using MediatR;

namespace Application.Features.Expenses;

public static class AddExpense
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var expenseToAdd = new Expense
            {
                Id = Guid.NewGuid(),
                Amount = request.AddedExpense.Amount,
                Category = request.AddedExpense.Category,
                Date = DateTime.UtcNow,
                Description = request.AddedExpense.Description,
            };
            dbContext.Expenses.Add(expenseToAdd);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return new Response(expenseToAdd);
        }
    }
    
    public record Request(AddedExpense AddedExpense) : IRequest<Response>;

    public record Response(Expense InsertedExpense);
}

public record AddedExpense(int Amount, ExpenseCategory Category, string Description);