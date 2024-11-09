using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Database;
using Application.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Authentication;

public static class CreateUser
{
    public class Handler(ExpensesDbContext dbContext) : IRequestHandler<Request>
    {
        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password
            };
            
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public record Request(string Username, string Password) : IRequest;
}