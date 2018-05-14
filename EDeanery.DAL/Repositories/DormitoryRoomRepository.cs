using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Mappers.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using DormitoryRoom = EDeanery.BLL.Domain.Entities.DormitoryRoom;

namespace EDeanery.DAL.Repositories
{
    public class DormitoryRoomRepository : IDormitoryRoomRepository
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

        public async Task AddStudentAsync(int studentId, int dormitoryRoomId)
        {
            var dormitoryRoom =
                await _context.DormitoryRooms.SingleOrDefaultAsync(dr => dr.DormitoryRoomId == dormitoryRoomId);
            var student = await _context.Students.SingleOrDefaultAsync(s => s.StudentId == studentId);

            var dormitoryRoomStudent = new DormitoryRoomStudentEntity
            {
                DormitoryRoomId = dormitoryRoom.DormitoryRoomId,
                StudentId = student.StudentId,
            };
            
            await _context.DormitoryRoomStudents.AddAsync(dormitoryRoomStudent);
        }

        public async Task DeleteStudentAsync(int studentId, int dormitoryRoomId)
        {
            var dormitoryRoomStudent = await _context.DormitoryRoomStudents.SingleOrDefaultAsync(dr =>
                dr.StudentId == studentId && dr.DormitoryRoomId == dormitoryRoomId);
            _context.DormitoryRoomStudents.Remove(dormitoryRoomStudent);
        }
    }
}