using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Mappers.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    public class DormitoryRepository : IDormitoryRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Dormitory, DAOs.DormitoryEntity> _dormitoryMapper;
        private readonly IMapper<DAOs.DormitoryEntity, Dormitory> _daoDormitoryMapper;

        public DormitoryRepository(
            IEdeaneryDbContext context,
            IMapper<Dormitory, DAOs.DormitoryEntity> dormitoryMapper,
            IMapper<DAOs.DormitoryEntity, Dormitory> daoDormitoryMapper)
        {
            _context = context;
            _dormitoryMapper = dormitoryMapper;
            _daoDormitoryMapper = daoDormitoryMapper;
        }

        public async Task AddAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            await _context.Dormitories.AddAsync(dao);
        }

        public async Task DeleteAsync(int id)
        {
            var dormitory = await _context.Dormitories.SingleOrDefaultAsync(d => d.DormitoryId == id);
            _context.Dormitories.Remove(dormitory);
        }

        public void UpdateAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            _context.Dormitories.Update(dao);
        }

        public async Task<ICollection<Dormitory>> GetAll()
        {
            var dormitoryDaos = await _context.Dormitories.ToListAsync();
            return dormitoryDaos.Select(d => _daoDormitoryMapper.Map(d)).ToList();
        }

        public async Task<Dormitory> GetById(int id)
        {
            return _daoDormitoryMapper.Map(await _context.Dormitories.SingleOrDefaultAsync(d => d.DormitoryId == id));
        }
    }
}