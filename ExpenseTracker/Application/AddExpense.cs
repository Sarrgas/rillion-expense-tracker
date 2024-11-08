using Application.Database;
using Application.Database.Entities;
using MediatR;
namespace Application;

public static class AddExpense
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<Request>
    {
        public Task Handle(Request request, CancellationToken cancellationToken)
        {
            dbContext.Expenses.Add(request.ExpenseToAdd);
            dbContext.SaveChanges();
            
            return Task.CompletedTask;
        }
    }
    
    public record Request(Expense ExpenseToAdd) : IRequest;
}