using System.Security.Claims;
using Application.Database;
using Application.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Expenses;

public static class GetAllExpenses
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<ForUserId, Response>
    {
        public async Task<Response> Handle(ForUserId request, CancellationToken cancellationToken)
        {
            var allExpenses = await dbContext.Expenses.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken: cancellationToken);
            return new Response(allExpenses);
        }
    }

    public record ForUserId(int UserId) : IRequest<Response>;
    public record Response(IEnumerable<Expense> AllExpensesForUser);
}