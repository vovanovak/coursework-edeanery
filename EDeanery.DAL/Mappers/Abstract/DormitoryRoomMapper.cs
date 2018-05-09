using System.Linq;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class DormitoryRoomMapper : IMapper<DormitoryRoom, DAOs.DormitoryRoom>, IMapper<DAOs.DormitoryRoom, DormitoryRoom>
    {
        public DAOs.DormitoryRoom Map(DormitoryRoom entity)
        {
            throw new System.NotImplementedException();
        }

        public DormitoryRoom Map(DAOs.DormitoryRoom entity)
        {
            throw new System.NotImplementedException();
        }
    }
}