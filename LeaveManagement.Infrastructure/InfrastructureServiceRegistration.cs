﻿//using LeaveManagement.Infrastructure.Mail;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace LeaveManagement.Infrastructure;
//public class InfrastructureServiceRegistration
//{
//    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
//    {
//        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
//        services.AddTransient<IEmailSender, EmailSender>();

//        return services;
//    }
//}
