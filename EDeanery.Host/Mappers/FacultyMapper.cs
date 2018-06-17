using EDeanery.Domain.Entities;
using EDeanery.Host.Models;
using EDeanery.Mappers.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.Host.Mappers
{
    public class FacultyMapper : IMapper<Faculty, SelectListItem>, 
        IMapper<Faculty, FacultySelectModel>
    {
        public SelectListItem Map(Faculty entity)
        {
            return new SelectListItem()
            {
                Value = entity.FacultyId.ToString(),
                Text = entity.Name
            };
        }

        FacultySelectModel IMapper<Faculty, FacultySelectModel>.Map(Faculty entity)
        {
            return new FacultySelectModel
            {
                Id = entity.FacultyId,
                Name = entity.Name,
                Checked = false
            }; 
        }
    }
}