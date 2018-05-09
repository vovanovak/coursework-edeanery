using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class GroupMapper : IMapper<Group, DAOs.Group>, IMapper<DAOs.Group, Group>
    {
        public DAOs.Group Map(Group entity)
        {
            throw new System.NotImplementedException();
        }

        public Group Map(DAOs.Group entity)
        {
            throw new System.NotImplementedException();
        }
    }
}