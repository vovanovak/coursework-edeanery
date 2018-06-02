using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Models;
using EDeanery.Mappers.Extensions;

namespace EDeanery.PL.Mappers
{
    public class DormitoryRoomMapper : 
        IMapper<DormitoryRoom, DormitoryRoomGetModel>,
        IMapper<DormitoryRoom, DormitoryRoomSelectModel>
    {
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;

        public DormitoryRoomMapper(IMapper<Student, StudentGetModel> studentGetModelMapper)
        {
            _studentGetModelMapper = studentGetModelMapper;
        }

        DormitoryRoomGetModel IMapper<DormitoryRoom, DormitoryRoomGetModel>.Map(DormitoryRoom entity)
        {
            return new DormitoryRoomGetModel
            {
                DormitoryRoomId = entity.DormitoryRoomId,
                DormityRoomName = entity.DormityRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                DormitoryId = entity.DormitoryId,
                DormitoryRoomStudents = _studentGetModelMapper.Map(entity.Roomers).ToList(),
            };
        }

        DormitoryRoomSelectModel IMapper<DormitoryRoom, DormitoryRoomSelectModel>.Map(DormitoryRoom entity)
        {
            var dormitoryGetModelMapper = (IMapper<DormitoryRoom, DormitoryRoomGetModel>) this;
            return new DormitoryRoomSelectModel(false, dormitoryGetModelMapper.Map(entity));
        }
    }
}