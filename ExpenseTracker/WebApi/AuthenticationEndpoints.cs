using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Database.Entities;
using Application.Features;
using Application.Features.Authentication;
using Azure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi;

public static class AuthenticationEndpoints
{
    public static IApplicationBuilder MapAuthenticationEndpoints(this WebApplication app)
    {
        var authentication = app
            .MapGroup("/authentication")
            .WithName("Authentication")
            .WithOpenApi();

        authentication.MapPost("login", async (ISender sender, IConfiguration config, [FromBody] LoginRequest loginRequest) =>
            {
                var response = await sender.Send(new Login.ByUsernameAndPassword(loginRequest.Username, loginRequest.Password));
                
                return response.Token;
            })
            .WithName("Login");

        return app;
    }
}

public class LoginRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
}