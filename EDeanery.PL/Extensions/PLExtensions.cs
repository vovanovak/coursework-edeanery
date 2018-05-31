﻿using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Mappers;
using EDeanery.PL.Models;
using EDeanery.PL.Providers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace EDeanery.PL.Extensions
{
    public static class PLExtensions
    {
        public static IServiceCollection AddPL(this IServiceCollection services)
        {
            return services.AddProviders().AddMappers();
        }

        private static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IViewBagDataProvider, ViewBagDataProvider>();

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<Faculty, SelectListItem>, FacultyMapper>();
            services.AddSingleton<IMapper<Speciality, SelectListItem>, SpecialityMapper>();

            services.AddSingleton<IMapper<Student, StudentGetModel>, StudentMapper>();
            services.AddSingleton<IMapper<Student, StudentGetDetailedModel>, StudentMapper>();
            services.AddSingleton<IMapper<StudentPostModel, Student>, StudentMapper>();
            services.AddSingleton<IMapper<Student, StudentPostModel>, StudentMapper>();
            services.AddSingleton<IMapper<Student, StudentSelectModel>, StudentMapper>();
            
            services.AddSingleton<IMapper<Group, GroupGetModel>, GroupMapper>();
            services.AddSingleton<IMapper<Group, GroupGetDetailedModel>, GroupMapper>();
            services.AddSingleton<IMapper<GroupPostModel, Group>, GroupMapper>();
            services.AddSingleton<IMapper<Group, GroupPostModel>, GroupMapper>();

            return services;
        }
    }
}