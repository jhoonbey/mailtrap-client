namespace MailSender.Extensions;

/// <summary>
/// MapperServicesExtensions
/// </summary>
public static class MapperServicesExtensions
{
    /// <summary>
    /// AddMapper
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}