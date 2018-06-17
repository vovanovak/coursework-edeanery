using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;
using EDeanery.Persistence.UnitOfWork.Abstract;

namespace EDeanery.Application.Services
{
    internal class FacultyService : Service<Faculty, int>, IFacultyService
    {
        public FacultyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Faculty, int> Repository => UnitOfWork.FacultyRepository;
    }
}