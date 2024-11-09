using Application.Database;
using Application.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public static class EditExpense
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<Request, Response>
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            //TODO Authorize user? Is this YOUR expense to edit?
            var expenseToEdit = await dbContext.Expenses.FirstAsync(x => x.Id == request.ExpenseId, cancellationToken: cancellationToken);
            expenseToEdit.Amount = request.EditedExpense.Amount;
            expenseToEdit.Category = request.EditedExpense.Category;
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return new Response(expenseToEdit);
        }
    }

    public record Request(Guid ExpenseId, EditableExpense EditedExpense) : IRequest<Response>;

    public record Response(Expense EditedExpense);
}

public record EditableExpense(int Amount, ExpenseCategory Category);