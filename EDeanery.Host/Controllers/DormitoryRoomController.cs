using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.Host.Constants;
using EDeanery.Host.Models;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.Host.Controllers
{
    public class DormitoryRoomController : Controller
    {
        private readonly IMapper<DormitoryRoom, DormitoryRoomGetModel> _dormitoryRoomGetModelMapper;
        private readonly IMapper<DormitoryRoomPostModel, DormitoryRoom> _dormitoryRoomMapper;
        private readonly IMapper<DormitoryRoom, DormitoryRoomPostModel> _dormitoryRoomPostModelMapper;
        private readonly IMapper<Dormitory, SelectListItem> _dormitorySelectModelMapper;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IMapper<Student, StudentSelectModel> _studentSelectModelMapper;
        private readonly IDormitoryRoomService _dormitoryRoomService;
        private readonly IDormitoryService _dormitoryService;
        private readonly IStudentService _studentService;

        public DormitoryRoomController(
            IMapper<DormitoryRoom, DormitoryRoomGetModel> dormitoryRoomGetModelMapper,
            IMapper<DormitoryRoomPostModel, DormitoryRoom> dormitoryRoomMapper,
            IMapper<DormitoryRoom, DormitoryRoomPostModel> dormitoryRoomPostModelMapper,
            IMapper<Dormitory, SelectListItem> dormitoryRoomModelMapper,
            IMapper<Student, StudentSelectModel> studentSelectModelMapper,
            IMapper<Student, StudentGetModel> studentGetModelMapper,
            IDormitoryRoomService dormitoryRoomService,
            IDormitoryService dormitoryService,
            IStudentService studentService)
        {
            _dormitoryRoomGetModelMapper = dormitoryRoomGetModelMapper;
            _dormitoryRoomMapper = dormitoryRoomMapper;
            _dormitoryRoomPostModelMapper = dormitoryRoomPostModelMapper;
            _dormitorySelectModelMapper = dormitoryRoomModelMapper;
            _studentSelectModelMapper = studentSelectModelMapper;
            _studentGetModelMapper = studentGetModelMapper;
            _dormitoryRoomService = dormitoryRoomService;
            _dormitoryService = dormitoryService;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dormitoryRooms = await _dormitoryRoomService.GetAll();
            var responseModels = _dormitoryRoomGetModelMapper.Map(dormitoryRooms).ToList();

            ViewBag.DormitoryRooms = responseModels;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDormitoryRoomById([FromQuery] int dormitoryRoomId)
        {
            var dormitoryRoom = await _dormitoryRoomService.GetById(dormitoryRoomId);

            ViewBag.Students = _studentGetModelMapper.Map(dormitoryRoom.Roomers).ToList();

            return View("DormitoryRoomDetailedView", _dormitoryRoomGetModelMapper.Map(dormitoryRoom));
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateDormitoryRoom([FromQuery] bool add, [FromQuery] int? dormitoryRoomId)
        {
            var students = await _studentService.GetStudentsWithoutRooms();
            var selectStudents = _studentSelectModelMapper.Map(students).ToList();

            var dormitories = await _dormitoryService.GetAll();
            var selectDormitories = _dormitorySelectModelMapper.Map(dormitories).ToList();
            
            selectDormitories.Insert(0, new SelectListItem() { Value = "-1", Text = "None" });
            
            DormitoryRoomPostModel model;

            if (add)
            {
                model = new DormitoryRoomPostModel();

                ViewBag.Header = ControllerConstants.AddDormitoryRoomHeader;
            }
            else
            {
                var dormitoryRoom = await _dormitoryRoomService.GetById(dormitoryRoomId.GetValueOrDefault());
                model = _dormitoryRoomPostModelMapper.Map(dormitoryRoom);

                foreach (var student in selectStudents)
                {
                    if (model.Students.Contains(student.StudentId))
                        student.Checked = true;
                }

                if (dormitoryRoom.DormitoryName == null)
                    selectDormitories[0].Selected = true;
                else
                    selectDormitories.Single(d => d.Text == dormitoryRoom.DormitoryName).Selected = true;
                
                ViewBag.Header = ControllerConstants.UpdateDormitoryRoomHeader;
            }

            ViewBag.Students = selectStudents;
            ViewBag.Dormitories = selectDormitories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDormitoryRoom(
            [FromBody] DormitoryRoomPostModel dormitoryRoomPostModel,
            [FromQuery] bool add = true)
        {
            var dormitoryRoom = _dormitoryRoomMapper.Map(dormitoryRoomPostModel);

            if (add)
                await _dormitoryRoomService.AddAsync(dormitoryRoom);
            else
                await _dormitoryRoomService.UpdateAsync(dormitoryRoom);

            await _dormitoryRoomService.SetDormitoryRoomStudentsAsync(dormitoryRoom.DormitoryRoomId,
                dormitoryRoomPostModel.Students.AsReadOnlyCollection());

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public JsonResult CheckDormitoryRoomName([FromQuery] string name)
        {
            var isValid = _dormitoryRoomService.IsDormitoryRoomNameUnique(name);
            return Json(new {IsValid = isValid, Message = ValidatorConstants.DormitoryNameIsNotUnique});
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteDormitoryRoom([FromQuery] int dormitoryRoomId)
        {
            await _dormitoryRoomService.DeleteAsync(dormitoryRoomId);
            return Ok();
        }
    }
}