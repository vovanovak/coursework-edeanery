using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
{
    internal class DormitoryRepository : IDormitoryRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Dormitory, DormitoryEntity> _dormitoryMapper;
        private readonly IMapper<DormitoryEntity, Dormitory> _daoDormitoryMapper;

        public DormitoryRepository(
            IEdeaneryDbContext context,
            IMapper<Dormitory, DormitoryEntity> dormitoryMapper,
            IMapper<DormitoryEntity, Dormitory> daoDormitoryMapper)
        {
            _context = context;
            _dormitoryMapper = dormitoryMapper;
            _daoDormitoryMapper = daoDormitoryMapper;
        }

        private IQueryable<DormitoryEntity> GetDormitoriesWithIncludes()
        {
            return _context.Dormitories
                .Include(d => d.DormitoryFaculties)
                .ThenInclude(df => df.FacultyEntity)
                .Include(d => d.DormitoryRooms)
                .ThenInclude(d => d.DormitoryRoomStudents)
                .ThenInclude(drs => drs.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        public async Task AddAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            await _context.Dormitories.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.DormitoryId = dao.DormitoryId;
        }

        public async Task DeleteAsync(int id)
        {
            var dormitory = await _context.Dormitories.SingleOrDefaultAsync(d => d.DormitoryId == id);
            _context.Dormitories.Remove(dormitory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            _context.Dormitories.Update(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Dormitory>> GetAll()
        {
            var dormitoryDaos = await GetDormitoriesWithIncludes().ToListAsync();
            return dormitoryDaos.Select(d => _daoDormitoryMapper.Map(d)).ToList();
        }

        public async Task<Dormitory> GetById(int id)
        {
            var dormitoryEntity = await GetDormitoriesWithIncludes().SingleOrDefaultAsync(d => d.DormitoryId == id);
            return _daoDormitoryMapper.Map(dormitoryEntity);
        }

        public bool IsDormitoryNameUnique(string dormitoryName)
        {
            return _context.Dormitories.All(d => d.Name != dormitoryName);
        }
    }
}