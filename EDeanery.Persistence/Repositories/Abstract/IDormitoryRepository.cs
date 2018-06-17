using EDeanery.Domain.Entities;

namespace EDeanery.Persistence.Repositories.Abstract
{
    public interface IDormitoryRepository : IRepository<Dormitory, int>
    {
        bool IsDormitoryNameUnique(string dormitoryName);
    }
}