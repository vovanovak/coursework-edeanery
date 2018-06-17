using System.Collections.Generic;
using System.Linq;
using EDeanery.DAL.DAOs;
using EDeanery.Domain.Entities;
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
                Address = entity.Address,
                NumberOfFlors = entity.NumberOfFlors,
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
                CountOfFreeSpaces = entity.DormitoryRooms.Sum(dr => dr.MaxCountInRoom) - 
                                    entity.DormitoryRooms.Select(dr => dr.DormitoryRoomStudents.Count).Sum(),
                MaxCountOfMembers = entity.DormitoryRooms?.Sum(dr => dr.MaxCountInRoom) ?? 0,
                Address = entity.Address,
                NumberOfFlors = entity.NumberOfFlors,
                MainFaculties = (entity.DormitoryFaculties ?? new List<DormitoryFacultyEntity>())
                    .Select(f => new Faculty()
                    {
                        FacultyId = f.FacultyId,
                        Name = f.FacultyEntity.Name
                    }).ToList(),
                Rooms = entity.DormitoryRooms == null ? new List<DormitoryRoom>() : _dormitoryRoomMapper.Map(entity.DormitoryRooms).ToList()
            };
        }
    }
}