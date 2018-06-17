using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class DormitoryService : Service<Dormitory, int>, IDormitoryService
    {
        private readonly IDormitoryRepository _dormitoryRepository;
        
        public DormitoryService(IDormitoryRepository dormitoryRepository) : base(dormitoryRepository)
        {
            _dormitoryRepository = dormitoryRepository;
        }

        public bool IsDormitoryNameUnique(string dormitoryName)
        {
            return _dormitoryRepository.IsDormitoryNameUnique(dormitoryName);
        }
    }
}