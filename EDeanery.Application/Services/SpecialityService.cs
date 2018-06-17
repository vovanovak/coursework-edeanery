using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class SpecialityService : Service<Speciality, int>, ISpecialityService
    {
        private readonly ISpecialityRepository _specialityRepository;

        public SpecialityService(ISpecialityRepository specialityRepository) : base(specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task<IReadOnlyCollection<Speciality>> GetByFacultyId(int facultyId)
        {
            return await _specialityRepository.GetByFacultyId(facultyId);
        }
    }
}