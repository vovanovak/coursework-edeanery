using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class SpecialityMapper : IMapper<Speciality, DAOs.Speciality>, IMapper<DAOs.Speciality, Speciality>
    {
        public DAOs.Speciality Map(Speciality entity)
        {
            throw new System.NotImplementedException();
        }

        public Speciality Map(DAOs.Speciality entity)
        {
            throw new System.NotImplementedException();
        }
    }
}