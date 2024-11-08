using Application.Database;
using Application.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public static class EditExpense
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<Request>
    {
        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            //TODO Authorize user? Is this YOUR expense to edit?
            var expenseToEdit = await dbContext.Expenses.FirstAsync(x => x.Id == request.ExpenseId, cancellationToken: cancellationToken);
            expenseToEdit.Amount = request.EditedExpense.Amount;
            expenseToEdit.Category = request.EditedExpense.Category;
            // dbContext.Expenses.Update(expenseToEdit);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public record Request(Guid ExpenseId, EditableExpense EditedExpense) : IRequest;
}

public class EditableExpense
{
    public int Amount { get; set; }
    public ExpenseCategory Category { get; set; }
}