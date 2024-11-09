using Application.Database;
using Application.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public static class GetAllExpenses
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<ForUser, Response>
    {
        public async Task<Response> Handle(ForUser request, CancellationToken cancellationToken)
        {
            var allExpenses = await dbContext.Expenses.ToListAsync(cancellationToken: cancellationToken);

            return new Response(allExpenses);
        }
    }

    public record ForUser : IRequest<Response>; //TODO Filter by user
    public record Response(IEnumerable<Expense> AllExpensesForUser);
}