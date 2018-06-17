using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
{
    internal class DormitoryRepository : Repository<Dormitory, DormitoryEntity, int>, IDormitoryRepository
    {
        public DormitoryRepository(
            IEdeaneryDbContext context,
            IMapper<Dormitory, DormitoryEntity> dormitoryMapper,
            IMapper<DormitoryEntity, Dormitory> daoDormitoryMapper) : base(context, dormitoryMapper, daoDormitoryMapper)
        {
        }

        protected override DbSet<DormitoryEntity> Table => Context.Dormitories;
        protected override IQueryable<DormitoryEntity> GetWithAllIncludes()
        {
            return Context.Dormitories
                .Include(d => d.DormitoryFaculties)
                .ThenInclude(df => df.FacultyEntity)
                .Include(d => d.DormitoryRooms)
                .ThenInclude(d => d.DormitoryRoomStudents)
                .ThenInclude(drs => drs.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        protected override Expression<Func<DormitoryEntity, bool>> GetDaoById(int id)
        {
            return dormitory => dormitory.DormitoryId == id;
        }

        protected override void SetId(Dormitory entity, DormitoryEntity dao)
        {
            entity.DormitoryId = dao.DormitoryId;
        }
        
        public bool IsDormitoryNameUnique(string dormitoryName)
        {
            return Table.All(d => d.Name != dormitoryName);
        }
    }
}