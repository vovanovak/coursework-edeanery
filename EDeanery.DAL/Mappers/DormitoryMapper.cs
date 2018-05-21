using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.DAOs;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;

namespace EDeanery.DAL.Mappers
{
    internal class DormitoryMapper : IMapper<Dormitory, DormitoryEntity>, IMapper<DormitoryEntity, Dormitory>
    {
        private readonly IMapper<DormitoryRoomEntity, DormitoryRoom> _dormitoryRoomMapper;


        public DormitoryMapper(
            IMapper<DormitoryRoomEntity, DormitoryRoom> dormitoryRoomMapper)
        {
            _dormitoryRoomMapper = dormitoryRoomMapper;
        }
        
        public DormitoryEntity Map(Dormitory entity)
        {
            return new DormitoryEntity
            {
                DormitoryId = entity.DormitoryId,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                Name = entity.Name,
                DormitoryFaculties = entity.MainFaculties.Select(f => new DormitoryFacultyEntity
                {
                    DormitoryId = entity.DormitoryId,
                    FacultyId = f.FacultyId
                }).ToList()
            };
        }

        public Dormitory Map(DormitoryEntity entity)
        {
            return new Dormitory
            {
                DormitoryId = entity.DormitoryId,
                Name = entity.Name,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                MainFaculties = entity.DormitoryFaculties.Select(f => new Faculty()
                {
                    FacultyId = f.FacultyId,
                    Name = f.FacultyEntity.Name
                }).ToList(),
                Rooms = _dormitoryRoomMapper.Map(entity.DormitoryRooms).ToList()
            };
        }
    }
}