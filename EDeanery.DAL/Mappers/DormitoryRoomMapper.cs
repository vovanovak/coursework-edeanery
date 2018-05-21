using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.DAOs;
using EDeanery.Mappers.Abstract;

namespace EDeanery.DAL.Mappers
{
    internal class DormitoryRoomMapper : IMapper<DormitoryRoom, DormitoryRoomEntity>, IMapper<DormitoryRoomEntity, DormitoryRoom>
    {
        private readonly IMapper<StudentEntity, Student> _studentMapper;

        public DormitoryRoomMapper(IMapper<StudentEntity, Student> studentMapper)
        {
            _studentMapper = studentMapper;
        }
        
        public DormitoryRoomEntity Map(DormitoryRoom entity)
        {
            return new DormitoryRoomEntity
            {
                DormitoryRoomId = entity.DormitoryRoomId,
                DormityRoomName = entity.DormityRoomName,
                MaxCountInRoom = entity.MaxCountInRoom
            };
        }

        public DormitoryRoom Map(DormitoryRoomEntity entity)
        {
            return new DormitoryRoom
            {
                DormitoryRoomId = entity.DormitoryRoomId,
                DormityRoomName = entity.DormityRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                Roomers = entity.DormitoryRoomStudents.Select(s => _studentMapper.Map(s.StudentEntity)).ToList()
            };
        }
    }
}