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

        public async Task AddAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            await _context.DormitoryRooms.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.DormitoryRoomId = dao.DormitoryRoomId;
        }

        public async Task DeleteAsync(int id)
        {
            var dao = await _context.DormitoryRooms.SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id);
            _context.DormitoryRooms.Remove(dao);
        }

        public void UpdateAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            _context.DormitoryRooms.Update(dao);
        }

        public async Task<ICollection<DormitoryRoom>> GetAll()
        {
            var dormitoryRoomDaos = await _context.DormitoryRooms.ToListAsync();
            return dormitoryRoomDaos.Select(dr => _daoDormitoryRoomMapper.Map(dr)).ToList();
        }

        public async Task<DormitoryRoom> GetById(int id)
        {
            return _daoDormitoryRoomMapper.Map(
                await _context.DormitoryRooms.SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id));
        }


        public async Task SetStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            var oldDormitoryRoomStudents =
                _context.DormitoryRoomStudents.Where(drs => drs.DormitoryRoomId == dormitoryRoomId);

            var newDormitoryRoomStudents =
                studentIds.Select(studentId => new DormitoryRoomStudentEntity()
                {
                    StudentId = studentId,
                    DormitoryRoomId = dormitoryRoomId
                });

            _context.DormitoryRoomStudents.RemoveRange(oldDormitoryRoomStudents);
            await _context.DormitoryRoomStudents.AddRangeAsync(newDormitoryRoomStudents);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            var freeDormitoryRooms = await _context.DormitoryRooms.Include(dr => dr.DormitoryRoomStudents)
                .Where(dr => dr.DormitoryRoomStudents.Count() < dr.MaxCountInRoom).ToListAsync();

            return _daoDormitoryRoomMapper.Map(freeDormitoryRooms).ToList();
        }
    }
}