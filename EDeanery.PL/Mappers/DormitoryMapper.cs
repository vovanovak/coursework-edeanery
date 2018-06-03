﻿using System;
using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.PL.Mappers
{
    public class DormitoryMapper :
        IMapper<Dormitory, DormitoryGetModel>,
        IMapper<DormitoryPostModel, Dormitory>,
        IMapper<Dormitory, DormitoryPostModel>,
        IMapper<Dormitory, SelectListItem>
    {
        private readonly IMapper<DormitoryRoom, DormitoryRoomGetModel> _dormitoryRoomGetModelMapper;

        public DormitoryMapper(IMapper<DormitoryRoom, DormitoryRoomGetModel> dormitoryRoomGetModelMapper)
        {
            _dormitoryRoomGetModelMapper = dormitoryRoomGetModelMapper;
        }

        DormitoryGetModel IMapper<Dormitory, DormitoryGetModel>.Map(Dormitory entity)
        {
            return new DormitoryGetModel
            {
                DormitoryId = entity.DormitoryId,
                Name = entity.Name,
                Address = entity.Address,
                NumberOfFlors = entity.NumberOfFlors,
                CountOfFreeSpaces = entity.CountOfFreeSpaces,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                Faculties = string.Join(", ", entity.MainFaculties.Select(f => f.Name)),
                DormitoryRoomGetModels =
                    entity.Rooms == null ? null : _dormitoryRoomGetModelMapper.Map(entity.Rooms).ToList(),
            };
        }

        public Dormitory Map(DormitoryPostModel entity)
        {
            return new Dormitory
            {
                DormitoryId = entity.DormitoryId,
                Name = entity.Name,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                Address = entity.Address,
                NumberOfFlors = entity.NumberOfFloors,
                MainFaculties = entity.Faculties?.Select(f => new Faculty {FacultyId = f}).ToList(),
                Rooms = entity.DormitoryRooms?.Select(d => new DormitoryRoom {DormitoryId = d}).ToList()
            };
        }

        DormitoryPostModel IMapper<Dormitory, DormitoryPostModel>.Map(Dormitory entity)
        {
            return new DormitoryPostModel
            {
                DormitoryId = entity.DormitoryId,
                Name = entity.Name,
                MaxCountOfMembers = entity.MaxCountOfMembers,
                Address = entity.Address,
                NumberOfFloors = entity.NumberOfFlors,
                Faculties = entity.MainFaculties?.Select(f => f.FacultyId).ToList(),
                DormitoryRooms = entity.Rooms?.Select(r => r.DormitoryRoomId).ToList(),
            };
        }

        public SelectListItem Map(Dormitory entity) => new SelectListItem
        {
            Value = Convert.ToString(entity.DormitoryId),
            Text = entity.Name
        };
    }
}