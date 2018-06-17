using System;
using System.Linq;
using System.Linq.Expressions;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
{
    internal class FacultyRepository : Repository<Faculty, FacultyEntity, int>, IFacultyRepository
    {
        public FacultyRepository(
            IEdeaneryDbContext context,
            IMapper<Faculty, FacultyEntity> facultyMapper,
            IMapper<FacultyEntity, Faculty> daoFacultyMapper)
            : base(context, facultyMapper, daoFacultyMapper)
        {
        }

        protected override DbSet<FacultyEntity> Table => Context.Faculties;

        protected override IQueryable<FacultyEntity> GetWithAllIncludes()
        {
            return Table.AsQueryable();
        }

        protected override Expression<Func<FacultyEntity, bool>> GetDaoById(int id)
        {
            return faculty => faculty.FacultyId == id;
        }

        protected override void SetId(Faculty entity, FacultyEntity dao)
        {
            entity.FacultyId = dao.FacultyId;
        }
    }
}