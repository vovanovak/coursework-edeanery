using System.Linq;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class DormitoryRoomMapper : IMapper<DormitoryRoom, DAOs.DormitoryRoomEntity>, IMapper<DAOs.DormitoryRoomEntity, DormitoryRoom>
    {
        private readonly IMapper<DAOs.StudentEntity, Student> _studentMapper;

        public DormitoryRoomMapper(IMapper<DAOs.StudentEntity, Student> studentMapper)
        {
            _studentMapper = studentMapper;
        }
        
        public DAOs.DormitoryRoomEntity Map(DormitoryRoom entity)
        {
            return new DAOs.DormitoryRoomEntity
            {
                DormitoryRoomId = entity.DormitoryRoomId,
                DormityRoomName = entity.DormityRoomName,
                MaxCountInRoom = entity.MaxCountInRoom
            };
        }

        public DormitoryRoom Map(DAOs.DormitoryRoomEntity entity)
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