using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.PL.Mappers
{
    public class SpecialityMapper : IMapper<Speciality, SelectListItem>
    {
        public SelectListItem Map(Speciality entity)
        {
            return new SelectListItem
            {
                Value = entity.SpecialityId.ToString(),
                Text = entity.SpecialityName,
            };
        }
    }
}