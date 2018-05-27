using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.PL.Mappers
{
    public class FacultyMapper : IMapper<Faculty, SelectListItem>
    {
        public SelectListItem Map(Faculty entity)
        {
            return new SelectListItem()
            {
                Value = entity.FacultyId.ToString(),
                Text = entity.Name
            };
        }
    }
}