using EDeanery.Application.Services;
using EDeanery.Application.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace EDeanery.Application.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            return AddServices(services);
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDormitoryRoomService, DormitoryRoomService>();
            services.AddScoped<IDormitoryService, DormitoryService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}