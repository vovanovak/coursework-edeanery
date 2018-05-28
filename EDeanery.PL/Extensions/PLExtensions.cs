using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Mappers;
using EDeanery.PL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            services.AddSingleton<IMapper<Student, StudentGetModel>, StudentMapper>();
            services.AddSingleton<IMapper<Student, StudentGetDetailedModel>, StudentMapper>();
            services.AddSingleton<IMapper<StudentPostModel, Student>, StudentMapper>();
            services.AddSingleton<IMapper<Student, StudentPostModel>, StudentMapper>();
            services.AddSingleton<IMapper<Faculty, SelectListItem>, FacultyMapper>();
            services.AddSingleton<IMapper<Speciality, SelectListItem>, SpecialityMapper>();

            return services;
        }
    }
}