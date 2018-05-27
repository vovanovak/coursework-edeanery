using Microsoft.Extensions.DependencyInjection;

namespace EDeanery.PL.Extensions
{
    public static class PLExtensions
    {
        public static IServiceCollection AddPL(this IServiceCollection services)
        {
            return services.AddMappers();
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services;
        }
    }
}