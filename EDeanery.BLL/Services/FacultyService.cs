using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class FacultyService : Service<Faculty, int>, IFacultyService
    {
        public FacultyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Faculty, int> Repository => UnitOfWork.FacultyRepository;
    }
}