using System.Linq;
using EDeanery.DAL.DAOs;
using Dormitory = EDeanery.BLL.Domain.Entities.Dormitory;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class DormitoryMapper : IMapper<Dormitory, DAOs.Dormitory>, IMapper<DAOs.Dormitory, Dormitory>
    {
        private readonly IMapper<DormitoryRoom, BLL.Domain.Entities.DormitoryRoom> _dormitoryRoomMapper;


        public DormitoryMapper(
            IMapper<DormitoryRoom, BLL.Domain.Entities.DormitoryRoom> dormitoryRoomMapper)
        {
            _dormitoryRoomMapper = dormitoryRoomMapper;
        }
        
        public DAOs.Dormitory Map(Dormitory entity)
        {
            return new DAOs.Dormitory
            {
                DormitoryId = entity.DormitoryId,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                Name = entity.Name,
                DormitoryFaculties = entity.MainFaculties.Select(f => new DormitoryFaculty
                {
                    DormitoryId = entity.DormitoryId,
                    FacultyId = f.FacultyId
                }).ToList()
            };
        }

        public Dormitory Map(DAOs.Dormitory entity)
        {
            return new Dormitory
            {
                DormitoryId = entity.DormitoryId,
                Name = entity.Name,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                MainFaculties = entity.DormitoryFaculties.Select(f => new BLL.Domain.Entities.Faculty()
                {
                    FacultyId = f.FacultyId,
                    Name = f.Faculty.Name
                }).ToList(),
                Rooms = entity.DormitoryRooms.Select(dr => _dormitoryRoomMapper.Map(dr)).ToList()
            };
        }
    }
}