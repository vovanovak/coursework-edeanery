using EDeanery.BLL.Services;
using EDeanery.BLL.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace EDeanery.BLL.DI
{
    public static class BLLExtensions
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
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
            services.AddScoped<StudentService, StudentService>();

            return services;
        }
    }
}