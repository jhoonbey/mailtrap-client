using MailTrapClient.Services;

namespace MailSender.Extensions;

/// <summary>
/// HttpClientExtensions
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// AddHttpClients
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IMailClient, MailClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(configuration["MailTrap:SendBaseUrl"]!);
        });

        return services;
    }
}