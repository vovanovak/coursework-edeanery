using EDeanery.Application.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;
using EDeanery.Domain.Entities;

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