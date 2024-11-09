using Application.Database.Entities;
using Application.Features;
using Application.Features.Expenses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public static class ExpensesEndpoints
{
    public static WebApplication MapExpensesEndpoints(this WebApplication app)
    {
        var expenses = app
            .MapGroup("/expenses")
            .WithName("Expenses")
            .WithOpenApi()
            .RequireAuthorization();

        expenses.MapPost("", async (ISender sender, [FromBody] AddedExpense addedExpense) =>
            {
                var response = await sender.Send(new AddExpense.Request(addedExpense));
                return response.InsertedExpense;
            })
            .WithName("PostExpense");
        
        expenses.MapGet("", async (ISender sender) =>
            {
                var response = await sender.Send(new GetAllExpenses.ForUser());
                return response.AllExpensesForUser;
            })
            .WithName("GetAllExpensesForUser");
        
        expenses.MapPatch("/{id}", async (ISender sender,[FromQuery] Guid id, [FromBody] EditableExpense editedExpense) =>
            {
                var response = await sender.Send(new EditExpense.Request(id, editedExpense));
                return response.EditedExpense;
            })
            .WithName("EditExpense");

        return app;
    }
}