using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IFacultyService _facultyService;
        private readonly ISpecialityService _specialityService;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IMapper<StudentPostModel, Student> _studentPostModelMapper;
        private readonly IMapper<Faculty, SelectListItem> _facultySelectListItemMapper;
        private readonly IMapper<Speciality, SelectListItem> _specialitySelectListItemMapper;


        public StudentController(IStudentService studentService,
            IFacultyService facultyService,
            ISpecialityService specialityService,
            IMapper<Student, StudentGetModel> studentGetModelMapper,
            IMapper<StudentPostModel, Student> studentPostModelMapper,
            IMapper<Faculty, SelectListItem> facultySelectListItemMapper,
            IMapper<Speciality, SelectListItem> specialitySelectListItemMapper)
        {
            _studentService = studentService;
            _facultyService = facultyService;
            _specialityService = specialityService;
            _studentGetModelMapper = studentGetModelMapper;
            _studentPostModelMapper = studentPostModelMapper;
            _facultySelectListItemMapper = facultySelectListItemMapper;
            _specialitySelectListItemMapper = specialitySelectListItemMapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.Students = _studentGetModelMapper.Map(await _studentService.GetAll());
            
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateStudent([FromQuery] bool add)
        {
            var faculties = await _facultyService.GetAll();
            ViewBag.Faculties = _facultySelectListItemMapper.Map(faculties);

            var specialities = await _specialityService.GetByFacultyId(faculties.First().FacultyId);
            ViewBag.Specialities = _specialitySelectListItemMapper.Map(specialities);
            
            ViewBag.Action = add ? "AddStudent" : "UpdateStudent";
            
            return View();
        }

        [HttpGet, Route("Student/GetSpecialitiesByFacultyId/{facultyId}")]
        public async Task<IEnumerable<SelectListItem>> GetSpecialitiesByFacultyId([FromRoute] int facultyId)
        {
            var specialities = await _specialityService.GetByFacultyId(facultyId);
            return _specialitySelectListItemMapper.Map(specialities);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddStudent([FromForm] StudentPostModel studentPostModel)
        {
            var student = _studentPostModelMapper.Map(studentPostModel);
            await _studentService.AddAsync(student);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent([FromForm] StudentPostModel studentPostModel)
        {
            var student = _studentPostModelMapper.Map(studentPostModel);
            await _studentService.UpdateAsync(student);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent([FromQuery] int studentId)
        {
            await _studentService.DeleteAsync(studentId);
            return Ok();
        }
    }
}