using System.Collections.Generic;
using System.Linq;
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
    internal class SpecialityRepository : ISpecialityRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Speciality, SpecialityEntity> _specialityMapper;
        private readonly IMapper<SpecialityEntity, Speciality> _daoSpecialityMapper;

        public SpecialityRepository(
            IEdeaneryDbContext context,
            IMapper<Speciality, SpecialityEntity> specialityMapper,
            IMapper<SpecialityEntity, Speciality> daoSpecialityMapper)
        {
            _context = context;
            _specialityMapper = specialityMapper;
            _daoSpecialityMapper = daoSpecialityMapper;
        }

        public async Task AddAsync(Speciality entity)
        {
            var dao = _specialityMapper.Map(entity);
            await _context.Specialities.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.SpecialityId = dao.SpecialityId;
        }

        public async Task DeleteAsync(int id)
        {
            var speciality = await _context.Specialities.SingleOrDefaultAsync(d => d.SpecialityId == id);
            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Speciality entity)
        {
            var dao = _specialityMapper.Map(entity);
            _context.Specialities.Update(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Speciality>> GetAll()
        {
            var specialityDaos = await WithIncludes().ToListAsync();
            return specialityDaos.Select(d => _daoSpecialityMapper.Map(d)).ToList();
        }

        public async Task<Speciality> GetById(int id)
        {
            return _daoSpecialityMapper.Map(await WithIncludes().SingleOrDefaultAsync(d => d.SpecialityId == id));
        }

        public async Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId)
        {
            var specialities = await WithIncludes().Where(s => s.FacultyId == facultyId).ToListAsync();
            return _daoSpecialityMapper.Map(specialities).ToList();
        }
        
        private IQueryable<SpecialityEntity> WithIncludes()
        {
            return _context.Specialities.Include(s => s.FacultyEntity);
        }
    }
}