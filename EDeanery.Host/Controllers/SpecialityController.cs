using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.Host.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ISpecialityService _specialityService;
        private readonly IMapper<Speciality, SelectListItem> _specialitySelectListItemMapper;

        public SpecialityController(
            ISpecialityService specialityService, 
            IMapper<Speciality, SelectListItem> specialitySelectListItemMapper)
        {
            _specialityService = specialityService;
            _specialitySelectListItemMapper = specialitySelectListItemMapper;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<SelectListItem>> GetSpecialitiesByFacultyId([FromRoute] int facultyId)
        {
            var specialities = await _specialityService.GetByFacultyId(facultyId);
            return _specialitySelectListItemMapper.Map(specialities).ToList(); 
        }
    }
}