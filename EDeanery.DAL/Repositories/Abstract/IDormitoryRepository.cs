using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IDormitoryRepository : IRepository<Dormitory, int>
    {
        bool IsDormitoryNameUnique(string dormitoryName);
    }
}