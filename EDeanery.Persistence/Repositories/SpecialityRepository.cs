using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
{
    internal class SpecialityRepository : Repository<Speciality, SpecialityEntity, int>, ISpecialityRepository
    {
        public SpecialityRepository(
            IEdeaneryDbContext context,
            IMapper<Speciality, SpecialityEntity> specialityMapper,
            IMapper<SpecialityEntity, Speciality> daoSpecialityMapper)
            : base(context, specialityMapper, daoSpecialityMapper)
        {
        }

        protected override DbSet<SpecialityEntity> Table => Context.Specialities;

        protected override IQueryable<SpecialityEntity> GetWithAllIncludes()
        {
            return Table.Include(s => s.FacultyEntity);
        }

        protected override Expression<Func<SpecialityEntity, bool>> GetDaoById(int id)
        {
            return speciality => speciality.SpecialityId == id;
        }

        protected override void SetId(Speciality entity, SpecialityEntity dao)
        {
            entity.SpecialityId = dao.SpecialityId;
        }

        public async Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId)
        {
            var specialityDaos = await Table.Where(s => s.FacultyId == facultyId).ToListAsync();
            return EntityMapper.Map(specialityDaos).ToList();
        }
    }
}