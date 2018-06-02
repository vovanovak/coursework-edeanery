using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.EntityFrameworkCore;
using DormitoryRoom = EDeanery.BLL.Domain.Entities.DormitoryRoom;

namespace EDeanery.DAL.Repositories
{
    internal class DormitoryRoomRepository : IDormitoryRoomRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<DormitoryRoom, DormitoryRoomEntity> _dormitoryRoomMapper;
        private readonly IMapper<DormitoryRoomEntity, DormitoryRoom> _daoDormitoryRoomMapper;

        public DormitoryRoomRepository(
            IEdeaneryDbContext context,
            IMapper<DormitoryRoom, DormitoryRoomEntity> dormitoryRoomMapper,
            IMapper<DormitoryRoomEntity, DormitoryRoom> daoDormitoryRoomMapper)
        {
            _context = context;
            _dormitoryRoomMapper = dormitoryRoomMapper;
            _daoDormitoryRoomMapper = daoDormitoryRoomMapper;
        }

        private IQueryable<DormitoryRoomEntity> GetDormitoryRoomsWithStudents()
        {
            return _context.DormitoryRooms.Include(dr => dr.DormitoryEntity)
                .Include(dr => dr.DormitoryRoomStudents);
        }

        public async Task AddAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            await _context.DormitoryRooms.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.DormitoryRoomId = dao.DormitoryRoomId;
        }

        public async Task DeleteAsync(int id)
        {
            var dao = await GetDormitoryRoomsWithStudents().SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id);
            _context.DormitoryRooms.Remove(dao);
        }

        public void UpdateAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            _context.DormitoryRooms.Update(dao);
        }

        public async Task<ICollection<DormitoryRoom>> GetAll()
        {
            var dormitoryRoomDaos = await GetDormitoryRoomsWithStudents().ToListAsync();
            return dormitoryRoomDaos.Select(dr => _daoDormitoryRoomMapper.Map(dr)).ToList();
        }

        public async Task<DormitoryRoom> GetById(int id)
        {
            return _daoDormitoryRoomMapper.Map(
                await GetDormitoryRoomsWithStudents().SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id));
        }


        public async Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            var oldDormitoryRooms = _context.DormitoryRooms.Where(dr => dr.DormitoryId == dormitoryId);

            foreach (var dormitoryRoom in oldDormitoryRooms)
            {
                dormitoryRoom.DormitoryId = null;
            }
            
            var dormitoryRooms = _context.DormitoryRooms.Where(dr => dormitoryRoomIds.Contains(dr.DormitoryRoomId));

            foreach (var dormitoryRoom in dormitoryRooms)
            {
                dormitoryRoom.DormitoryId = dormitoryId;
            }
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            var dormitoryRoomsDaos = await GetDormitoryRoomsWithStudents().Where(dr => dr.DormitoryId == dormitoryId).ToListAsync();
            return _daoDormitoryRoomMapper.Map(dormitoryRoomsDaos).ToList();
        }
        
        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            var freeDormitoryRooms = await GetDormitoryRoomsWithStudents()
                .Where(dr => dr.DormitoryRoomStudents.Count() < dr.MaxCountInRoom)
                .ToListAsync();

            return _daoDormitoryRoomMapper.Map(freeDormitoryRooms).ToList();
        }
    }
}