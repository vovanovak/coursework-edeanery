﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services.Abstract
{
    public interface IDormitoryRoomService : IService<DormitoryRoom, int>
    {
        Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds);
        Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory();
        bool IsDormitoryRoomNameUnique(string name);
    }
}