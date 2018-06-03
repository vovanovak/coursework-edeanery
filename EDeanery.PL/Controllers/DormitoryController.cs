using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Constants;
using EDeanery.PL.Models;
using EDeanery.PL.Providers;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.PL.Controllers
{
    public class DormitoryController : Controller
    {
        private readonly IMapper<Dormitory, DormitoryGetModel> _dormitoryGetModelMapper;
        private readonly IMapper<DormitoryPostModel, Dormitory> _dormitoryMapper;
        private readonly IMapper<Dormitory, DormitoryPostModel> _dormitoryPostModelMapper;
        private readonly IMapper<DormitoryRoom, DormitoryRoomGetModel> _dormitoryRoomGetModelMapper;
        private readonly IMapper<DormitoryRoom, DormitoryRoomSelectModel> _dormitoryRoomSelectModelMapper;
        private readonly IMapper<Faculty, FacultySelectModel> _facultySelectModelMapper;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IFacultyService _facultyService;
        private readonly IDormitoryService _dormitoryService;
        private readonly IDormitoryRoomService _dormitoryRoomService;

        public DormitoryController(
            IMapper<Dormitory, DormitoryGetModel> groupGetModelMapper,
            IMapper<DormitoryPostModel, Dormitory> groupMapper,
            IMapper<Dormitory, DormitoryPostModel> groupPostModelMapper,
            IMapper<DormitoryRoom, DormitoryRoomGetModel> dormitoryRoomGetModelMapper,
            IMapper<DormitoryRoom, DormitoryRoomSelectModel> dormitoryRoomSelectModelMapper,
            IMapper<Faculty, FacultySelectModel> facultySelectModelMapper,
            IMapper<Student, StudentGetModel> studentGetModelMapper, 
            IDormitoryService dormitoryService,
            IDormitoryRoomService dormitoryRoomService,
            IFacultyService facultyService)
        {
            _dormitoryGetModelMapper = groupGetModelMapper;
            _dormitoryMapper = groupMapper;
            _dormitoryPostModelMapper = groupPostModelMapper;
            _dormitoryRoomGetModelMapper = dormitoryRoomGetModelMapper;
            _dormitoryRoomSelectModelMapper = dormitoryRoomSelectModelMapper;
            _facultySelectModelMapper = facultySelectModelMapper;
            _studentGetModelMapper = studentGetModelMapper;
            _dormitoryService = dormitoryService;
            _dormitoryRoomService = dormitoryRoomService;
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dormitories = await _dormitoryService.GetAll();
            var responseModels = _dormitoryGetModelMapper.Map(dormitories).ToList();

            ViewBag.Dormitories = responseModels;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDormitoryById([FromQuery] int dormitoryId)
        {
            var dormitoryRooms = await _dormitoryRoomService.GetRoomsByDormitoryId(dormitoryId);
            var dormitory = await _dormitoryService.GetById(dormitoryId);
            var students = dormitoryRooms.SelectMany(dr => dr.Roomers).ToList();
            
            ViewBag.DormitoryRooms = _dormitoryRoomGetModelMapper.Map(dormitoryRooms).ToList();
            ViewBag.Students = _studentGetModelMapper.Map(students).ToList();

            return View("DormitoryDetailedView", _dormitoryGetModelMapper.Map(dormitory));
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateDormitory([FromQuery] bool add, [FromQuery] int? dormitoryId)
        {
            var dormitoryRooms = await _dormitoryRoomService.GetRoomsWithoutDormitory();
            var faculties = await _facultyService.GetAll();

            var selectedDormitoryRooms = _dormitoryRoomSelectModelMapper.Map(dormitoryRooms).ToList();
            var selectedFaculties = _facultySelectModelMapper.Map(faculties).ToList();
            DormitoryPostModel model;

            if (add)
            {
                model = new DormitoryPostModel();

                ViewBag.Header = ControllerConstants.AddDormitoryHeader;
            }
            else
            {
                var group = await _dormitoryService.GetById(dormitoryId.GetValueOrDefault());
                model = _dormitoryPostModelMapper.Map(group);

                foreach (var dormitoryRoom in selectedDormitoryRooms)
                {
                    if (model.DormitoryRooms.Contains(dormitoryRoom.DormitoryRoomId))
                        dormitoryRoom.Checked = true;
                }

                foreach (var faculty in selectedFaculties)
                {
                    if (model.Faculties.Contains(faculty.Id))
                        faculty.Checked = true;
                }

                ViewBag.Header = ControllerConstants.UpdateDormitoryHeader;
            }

            ViewBag.Faculties = selectedFaculties;
            ViewBag.DormitoryRooms = selectedDormitoryRooms;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDormitory(
            [FromBody] DormitoryPostModel dormitoryPostModel,
            [FromQuery] bool add = true)
        {
            var dormitory = _dormitoryMapper.Map(dormitoryPostModel);

            if (add)
                await _dormitoryService.AddAsync(dormitory);
            else
                await _dormitoryService.UpdateAsync(dormitory);

            await _dormitoryRoomService.SetDormitoryRoomsAsync(
                dormitory.DormitoryId, 
                dormitoryPostModel.DormitoryRooms.ToList());

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDormitory([FromQuery] int dormitoryId)
        {
            await _dormitoryService.DeleteAsync(dormitoryId);
            return Ok();
        }
    }
}