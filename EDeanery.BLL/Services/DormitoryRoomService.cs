﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal class DormitoryRoomService : Service<DormitoryRoom, int>, IDormitoryRoomService
    {
        public DormitoryRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<DormitoryRoom, int> Repository => UnitOfWork.DormitoryRoomRepository;


        public async Task SetStudentsAsync(int studentId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            await UnitOfWork.DormitoryRoomRepository.SetStudentsAsync(studentId, dormitoryRoomIds);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsWithFreeSpaces(dormitoryId);
        }
    }
}