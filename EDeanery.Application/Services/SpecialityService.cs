using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services
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