using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class FacultyService : Service<Faculty, int>, IFacultyService
    {
        public FacultyService(IFacultyRepository facultyRepository) : base(facultyRepository)
        {
        }
    }
}