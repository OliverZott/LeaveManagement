using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagement.Application;
public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddAutoMapper(typeof(MappingProfile));
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
