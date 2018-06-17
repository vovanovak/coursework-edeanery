﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;
using EDeanery.Persistence.UnitOfWork.Abstract;

namespace EDeanery.Application.Services
{
    internal class DormitoryRoomService : Service<DormitoryRoom, int>, IDormitoryRoomService
    {
        public DormitoryRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<DormitoryRoom, int> Repository => UnitOfWork.DormitoryRoomRepository;

        public async Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            UnitOfWork.DormitoryRoomRepository.SetDormitoryRooms(dormitoryId, dormitoryRoomIds);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            await UnitOfWork.DormitoryRoomRepository.SetDormitoryRoomStudentsAsync(dormitoryRoomId, studentIds);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsWithFreeSpaces(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsByDormitoryId(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory()
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsWithoutDormitory();
        }

        public bool IsDormitoryRoomNameUnique(string name)
        {
            return UnitOfWork.DormitoryRoomRepository.IsDormitoryRoomNameUnique(name);
        }
    }
}