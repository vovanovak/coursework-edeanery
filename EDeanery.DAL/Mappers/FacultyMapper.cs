using EDeanery.DAL.DAOs;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;

namespace EDeanery.DAL.Mappers
{
    internal class FacultyMapper : IMapper<Faculty, FacultyEntity>, IMapper<FacultyEntity, Faculty>
    {
        public FacultyEntity Map(Faculty entity)
        {
            return new FacultyEntity
            {
                FacultyId = entity.FacultyId,
                Name = entity.Name
            };
        }

        public Faculty Map(FacultyEntity entity)
        {
            return new Faculty
            {
                FacultyId = entity.FacultyId,
                Name = entity.Name
            };
        }
    }
}