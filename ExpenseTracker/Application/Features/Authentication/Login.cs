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

public static class Login
{
    public class Handler(ExpensesDbContext dbContext, IConfiguration configuration) : IRequestHandler<ByUsernameAndPassword, Response>
    {
        public async Task<Response> Handle(ByUsernameAndPassword request, CancellationToken cancellationToken)
        {
            var user = dbContext.Users.SingleOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                [new Claim("userid", user.Id.ToString()),],
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new Response(token!);
        }
    }

    public record ByUsernameAndPassword(string Username, string Password) : IRequest<Response>;
    public record Response(string Token);
}