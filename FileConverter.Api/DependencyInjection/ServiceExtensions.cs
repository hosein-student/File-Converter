using FileConverter.Application.Interfaces;
using FileConverter.Application.UseCases.ConvertImage;
using FileConverter.Infrastracture;

namespace FileConverter.Api.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IConvertImageUseCase, ConvertImageUseCase>();
        return services;
    }

    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<IConvertImageSevice, ConvertImageSevice>();
        return services;
    }
}