using MailSender.Services;

namespace MailSender.Extensions;

/// <summary>
/// ApplicationServicesExtensions
/// </summary>
public static class ApplicationServicesExtensions
{
    /// <summary>
    /// AddApplicationServices
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}