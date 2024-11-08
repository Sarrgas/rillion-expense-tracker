using Application.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ServiceConfiguration).Assembly))
            .AddDbContext<ExpensesDbContext>(options =>
            {
                options.UseSqlServer("ConnectionStringGoesHere");
            });
    }
}