using EDeanery.Application.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services
{
    internal class DormitoryService : Service<Dormitory, int>, IDormitoryService
    {
        public DormitoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Dormitory, int> Repository => UnitOfWork.DormitoryRepository;
        public bool IsDormitoryNameUnique(string dormitoryName)
        {
            return UnitOfWork.DormitoryRepository.IsDormitoryNameUnique(dormitoryName);
        }
    }
}