using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface ISpecialityService : IService<Speciality, int>
    {
        Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId);
    }
}