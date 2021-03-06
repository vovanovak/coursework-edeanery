﻿using System.Collections.Generic;
using System.Linq;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.DAOs;

namespace EDeanery.Persistence.Mappers
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
                DormitoryRoomName = entity.DormitoryRoomName,
                DormitoryId = entity.DormitoryId,
                MaxCountInRoom = entity.MaxCountInRoom
            };
        }

        public DormitoryRoom Map(DormitoryRoomEntity entity)
        {
            return new DormitoryRoom
            {
                DormitoryRoomId = entity.DormitoryRoomId,
                DormitoryRoomName = entity.DormitoryRoomName,
                MaxCountInRoom = entity.MaxCountInRoom,
                CountOfFreeSpaces = entity.MaxCountInRoom - entity.DormitoryRoomStudents?.Count ?? 0,
                DormitoryId = entity.DormitoryId,
                DormitoryName = entity.DormitoryEntity?.Name,
                Roomers = (entity.DormitoryRoomStudents ?? new List<DormitoryRoomStudentEntity>())
                    .Select(s => _studentMapper.Map(s.StudentEntity)).ToList(),
            };
        }
    }
}