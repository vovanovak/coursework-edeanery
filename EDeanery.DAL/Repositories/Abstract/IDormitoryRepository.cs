using EDeanery.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IDormitoryRepository : IRepository<Dormitory, int>
    {
        bool IsDormitoryNameUnique(string dormitoryName);
    }
}