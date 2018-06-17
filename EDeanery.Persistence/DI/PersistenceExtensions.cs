using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Mappers;
using EDeanery.Persistence.Repositories;
using EDeanery.Persistence.Repositories.Abstract;
using EDeanery.Persistence.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDeanery.Persistence.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddContext(configuration)
                .AddRepositories()
                .AddUnitOfWork()
                .AddMappers();
        }

        private static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMapper<Dormitory, DormitoryEntity>, DormitoryMapper>();
            serviceCollection.AddSingleton<IMapper<DormitoryEntity, Dormitory>, DormitoryMapper>();
            serviceCollection.AddSingleton<IMapper<DormitoryRoom, DormitoryRoomEntity>, DormitoryRoomMapper>();
            serviceCollection.AddSingleton<IMapper<DormitoryRoomEntity, DormitoryRoom>, DormitoryRoomMapper>();
            serviceCollection.AddSingleton<IMapper<Faculty, FacultyEntity>, FacultyMapper>();
            serviceCollection.AddSingleton<IMapper<FacultyEntity, Faculty>, FacultyMapper>();
            serviceCollection.AddSingleton<IMapper<Group, GroupEntity>, GroupMapper>();
            serviceCollection.AddSingleton<IMapper<GroupEntity, Group>, GroupMapper>();
            serviceCollection.AddSingleton<IMapper<Speciality, SpecialityEntity>, SpecialityMapper>();
            serviceCollection.AddSingleton<IMapper<SpecialityEntity, Speciality>, SpecialityMapper>();
            serviceCollection.AddSingleton<IMapper<Student, StudentEntity>, StudentMapper>();
            serviceCollection.AddSingleton<IMapper<StudentEntity, Student>, StudentMapper>();

            return serviceCollection;
        }

        private static IServiceCollection AddContext(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<EdeaneryDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnectionString");
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            serviceCollection.AddScoped<IEdeaneryDbContext, EdeaneryDbContext>();

            return serviceCollection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDormitoryRepository, DormitoryRepository>();
            serviceCollection.AddScoped<IDormitoryRoomRepository, DormitoryRoomRepository>();
            serviceCollection.AddScoped<IFacultyRepository, FacultyRepository>();
            serviceCollection.AddScoped<IGroupRepository, GroupRepository>();
            serviceCollection.AddScoped<ISpecialityRepository, SpecialityRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();

            return serviceCollection;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return serviceCollection;
        }
    }
}