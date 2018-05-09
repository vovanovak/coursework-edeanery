﻿using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class DormitoryService : Service<Dormitory, int>, IDormitoryService
    {
        public DormitoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Dormitory, int> Repository => UnitOfWork.DormitoryRepository;
    }
}