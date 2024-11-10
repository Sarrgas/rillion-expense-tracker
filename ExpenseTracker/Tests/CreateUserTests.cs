using Application.Database;
using Application.Features.Authentication;
using FluentAssertions;
using Tests.Common;

namespace Tests;

public class CreateUserTests
{
    private ExpensesDbContext _context;
    private CreateUser.Handler _sut;

    [SetUp]
    public void Setup()
    {
        _context = SqliteInMemoryDb.GetContext();
        _sut = new CreateUser.Handler(_context);
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GivenNoUserExists_WhenCreatingUser_ThenUserIsCreated()
    {
        await _sut.Handle(new CreateUser.Request("kalleanka", "julafton2024"), CancellationToken.None);
        
        _context.Users.FirstOrDefault(x => x.Username == "kalleanka").Should().NotBeNull();
    }
}