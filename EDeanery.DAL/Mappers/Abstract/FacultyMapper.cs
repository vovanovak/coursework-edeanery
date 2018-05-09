using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class FacultyMapper : IMapper<Faculty, DAOs.Faculty>, IMapper<DAOs.Faculty, Faculty>
    {
        public DAOs.Faculty Map(Faculty entity)
        {
            throw new System.NotImplementedException();
        }

        public Faculty Map(DAOs.Faculty entity)
        {
            throw new System.NotImplementedException();
        }
    }
}