using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IMapper<StudentPostModel, Student> _studentPostModelMapper;

        public StudentController(IStudentService studentService,
            IMapper<Student, StudentGetModel> studentGetModelMapper,
            IMapper<StudentPostModel, Student> studentPostModelMapper)
        {
            _studentService = studentService;
            _studentGetModelMapper = studentGetModelMapper;
            _studentPostModelMapper = studentPostModelMapper;
        }

        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetAll();
            var responseModels = _studentGetModelMapper.Map(students);

            ViewBag.Students = responseModels;
            
            return View();
        }

        public async Task<ActionResult> AddStudent([FromForm] StudentPostModel studentPostModel)
        {
            var student = _studentPostModelMapper.Map(studentPostModel);
            await _studentService.AddAsync(student);
            return Ok();
        }

        public async Task<ActionResult> UpdateStudent([FromForm] StudentPostModel studentPostModel)
        {
            var student = _studentPostModelMapper.Map(studentPostModel);
            await _studentService.UpdateAsync(student);
            return Ok();
        }

        public async Task<ActionResult> DeleteStudent([FromQuery] int studentId)
        {
            await _studentService.DeleteAsync(studentId);
            return Ok();
        }
    }
}