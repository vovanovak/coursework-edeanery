using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services.Abstract
{
    public interface IDormitoryService : IService<Dormitory, int>
    {
        bool IsDormitoryNameUnique(string dormitoryName);
    }
}