using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface ISpecialityRepository : IRepository<Speciality, int>
    {
        Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId);
    }
}