using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.PL.Mappers
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