using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.UnitOfWork;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Constants;
using EDeanery.PL.Models;
using EDeanery.PL.Providers;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IMapper<Student, StudentGetDetailedModel> _studentGetDetailedModelMapper;
        private readonly IMapper<StudentPostModel, Student> _studentPostModelMapper;
        private readonly IMapper<Student, StudentPostModel> _studentToPostModelMapper;
        private readonly IViewBagDataProvider _viewBagDataProvider;

        public StudentController(IStudentService studentService,
            IMapper<Student, StudentGetModel> studentGetModelMapper,
            IMapper<Student, StudentGetDetailedModel> studentGetDetailedModelMapper,
            IMapper<StudentPostModel, Student> studentPostModelMapper,
            IMapper<Student, StudentPostModel> studentToPostModelMapper,
            IViewBagDataProvider viewBagDataProvider)
        {
            _studentService = studentService;
            _studentGetModelMapper = studentGetModelMapper;
            _studentGetDetailedModelMapper = studentGetDetailedModelMapper;
            _studentToPostModelMapper = studentToPostModelMapper;
            _studentPostModelMapper = studentPostModelMapper;
            _viewBagDataProvider = viewBagDataProvider;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.Students = _studentGetModelMapper.Map(await _studentService.GetAll()).ToList();

            return View();
        }
        
        [HttpGet]
        public async Task<IReadOnlyCollection<StudentGetModel>> GetStudentsByFullName(
            [FromQuery] string search, 
            [FromQuery] int? groupId,
            [FromQuery] int? dormitoryId,
            [FromQuery] int? dormitoryRoomId)
        {
            var students = await _studentService.GetStudentsByFullName(search, groupId, dormitoryId, dormitoryRoomId);
            var responseModels = _studentGetModelMapper.Map(students).ToList();
            return responseModels;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<StudentGetModel>> GetStudentsByGroup(
            [FromQuery] string search,
            [FromQuery] int? groupId,
            [FromQuery] int? dormitoryId,
            [FromQuery] int? dormitoryRoomId)
        {
            var students = await _studentService.GetStudentsByGroup(search, groupId, dormitoryId, dormitoryRoomId);
            var responseModels = _studentGetModelMapper.Map(students).ToList();
            return responseModels;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentById([FromQuery] int studentId)
        {
            var student = await _studentService.GetById(studentId);
            return View("StudentDetailedView", _studentGetDetailedModelMapper.Map(student));
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateStudent([FromQuery] bool add, [FromQuery] int? studentId)
        {
            await _viewBagDataProvider.InitFacultiesAndSpecialities(this.ViewBag);

            StudentPostModel model;

            if (add)
            {
                model = new StudentPostModel();
                ViewBag.Header = ControllerConstants.AddStudentHeader;
            }
            else
            {
                var student = await _studentService.GetById(studentId.GetValueOrDefault());
                model = _studentToPostModelMapper.Map(student);
                ViewBag.Header = ControllerConstants.UpdateStudentHeader;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateStudent(
            [FromForm] StudentPostModel studentPostModel,
            [FromQuery] bool add)
        {
            var student = _studentPostModelMapper.Map(studentPostModel);
            if (add)
                await _studentService.AddAsync(student);
            else
                await _studentService.UpdateAsync(student);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent([FromQuery] int studentId)
        {
            await _studentService.DeleteAsync(studentId);
            return Ok();
        }
    }
}