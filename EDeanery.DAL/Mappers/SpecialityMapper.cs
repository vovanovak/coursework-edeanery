using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.DAOs;
using EDeanery.Mappers.Abstract;

namespace EDeanery.DAL.Mappers
{
    internal class SpecialityMapper : IMapper<Speciality, SpecialityEntity>, IMapper<SpecialityEntity, Speciality>
    {
        private readonly IMapper<FacultyEntity, Faculty> _facultyMapper;

        public SpecialityMapper(IMapper<FacultyEntity, Faculty> facultyMapper)
        {
            _facultyMapper = facultyMapper;
        }
        
        public SpecialityEntity Map(Speciality entity)
        {
            return new SpecialityEntity
            {
                SpecialityId = entity.SpecialityId,
                SpecialityName = entity.SpecialityName,
                FacultyId = entity.Faculty.FacultyId
            };
        }

        public Speciality Map(SpecialityEntity entity)
        {
            return new Speciality
            {
                SpecialityId = entity.SpecialityId,
                SpecialityName = entity.SpecialityName,
                Faculty = _facultyMapper.Map(entity.FacultyEntity)
            };
        }
    }
}