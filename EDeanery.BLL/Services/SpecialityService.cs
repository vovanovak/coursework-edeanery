using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal class SpecialityService : Service<Speciality, int>, ISpecialityService
    {
        public SpecialityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Speciality, int> Repository => UnitOfWork.SpecialityRepository;
        public async Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId)
        {
            return await UnitOfWork.SpecialityRepository.GetByFacultyId(facultyId);
        }
    }
}