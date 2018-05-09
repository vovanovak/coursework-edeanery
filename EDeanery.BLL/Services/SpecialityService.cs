using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class SpecialityService : Service<Speciality, int>, ISpecialityService
    {
        public SpecialityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Speciality, int> Repository => UnitOfWork.SpecialityRepository;
    }
}