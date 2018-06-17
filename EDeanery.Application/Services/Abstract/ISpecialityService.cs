using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services.Abstract
{
    public interface ISpecialityService : IService<Speciality, int>
    {
        Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId);
    }
}