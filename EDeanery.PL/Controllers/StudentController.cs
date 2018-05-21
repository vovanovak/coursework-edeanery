using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Services.Abstract;
using EDeanery.PL.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentMapper _studentMapper;

        public StudentController(IStudentService studentService, IStudentMapper studentMapper)
        {
            _studentService = studentService;
            _studentMapper = studentMapper;
        }

        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetAll();
            var responseModels = students.Select(s => _studentMapper.Map(s)).ToList();

            ViewBag.Students = responseModels;
            
            return View();
        }
    }
}