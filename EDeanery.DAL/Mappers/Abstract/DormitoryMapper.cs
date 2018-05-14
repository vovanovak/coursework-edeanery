using System.Linq;
using EDeanery.DAL.DAOs;
using Dormitory = EDeanery.BLL.Domain.Entities.Dormitory;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class DormitoryMapper : IMapper<Dormitory, DormitoryEntity>, IMapper<DormitoryEntity, Dormitory>
    {
        private readonly IMapper<DormitoryRoomEntity, BLL.Domain.Entities.DormitoryRoom> _dormitoryRoomMapper;


        public DormitoryMapper(
            IMapper<DormitoryRoomEntity, BLL.Domain.Entities.DormitoryRoom> dormitoryRoomMapper)
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
                MainFaculties = entity.DormitoryFaculties.Select(f => new BLL.Domain.Entities.Faculty()
                {
                    FacultyId = f.FacultyId,
                    Name = f.FacultyEntity.Name
                }).ToList(),
                Rooms = entity.DormitoryRooms.Select(dr => _dormitoryRoomMapper.Map(dr)).ToList()
            };
        }
    }
}