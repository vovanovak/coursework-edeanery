using System.Linq;
using EDeanery.Domain.Entities;
using EDeanery.Host.Models;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;

namespace EDeanery.Host.Mappers
{
    public class DormitoryRoomMapper : 
        IMapper<DormitoryRoom, DormitoryRoomGetModel>,
        IMapper<DormitoryRoomPostModel, DormitoryRoom>,
        IMapper<DormitoryRoom, DormitoryRoomPostModel>,
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
                DormitoryRoomName = entity.DormitoryRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                FreeSpacesCount = entity.CountOfFreeSpaces,
                Dormitory = entity.DormitoryId == null ? null : new DormitoryGetModel
                {
                    DormitoryId = entity.DormitoryId,
                    Name = entity.DormitoryName
                },
                DormitoryRoomStudents = _studentGetModelMapper.Map(entity.Roomers).ToList(),
            };
        }

        DormitoryRoomSelectModel IMapper<DormitoryRoom, DormitoryRoomSelectModel>.Map(DormitoryRoom entity)
        {
            var dormitoryGetModelMapper = (IMapper<DormitoryRoom, DormitoryRoomGetModel>) this;
            return new DormitoryRoomSelectModel(false, dormitoryGetModelMapper.Map(entity));
        }

        public DormitoryRoom Map(DormitoryRoomPostModel entity)
        {
            return new DormitoryRoom
            {
                DormitoryId = entity.DormitoryId,
                DormitoryRoomName = entity.DormitoryRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                DormitoryRoomId = entity.DormitoryRoomId,
                Roomers = entity.Students.Select(s => new Student
                {
                    StudentId = s
                }).ToList()
            };
        }

        public DormitoryRoomPostModel Map(DormitoryRoom entity)
        {
            return new DormitoryRoomPostModel
            {
                DormitoryId = entity.DormitoryId == null ? -1 : entity.DormitoryId.Value,
                DormitoryRoomId = entity.DormitoryRoomId,
                DormitoryRoomName = entity.DormitoryRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                Students = entity.Roomers.Select(s => s.StudentId).ToList()
            };
        }
    }
}