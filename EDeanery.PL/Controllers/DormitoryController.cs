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
        private readonly IViewBagDataProvider _viewBagDataProvider;
        private readonly IDormitoryService _dormitoryService;
        private readonly IDormitoryRoomService _dormitoryRoomService;

        public DormitoryController(
            IMapper<Dormitory, DormitoryGetModel> groupGetModelMapper,
            IMapper<DormitoryPostModel, Dormitory> groupMapper,
            IMapper<Dormitory, DormitoryPostModel> groupPostModelMapper,
            IMapper<DormitoryRoom, DormitoryRoomGetModel> dormitoryRoomGetModelMapper,
            IMapper<DormitoryRoom, DormitoryRoomSelectModel> dormitoryRoomSelectModelMapper,
            IDormitoryService dormitoryService,
            IDormitoryRoomService dormitoryRoomService,
            IViewBagDataProvider viewBagDataProvider)
        {
            _dormitoryGetModelMapper = groupGetModelMapper;
            _dormitoryMapper = groupMapper;
            _dormitoryPostModelMapper = groupPostModelMapper;
            _dormitoryRoomGetModelMapper = dormitoryRoomGetModelMapper;
            _dormitoryRoomSelectModelMapper = dormitoryRoomSelectModelMapper;
            _dormitoryService = dormitoryService;
            _dormitoryRoomService = dormitoryRoomService;
            _viewBagDataProvider = viewBagDataProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var groups = await _dormitoryService.GetAll();
            var responseModels = _dormitoryGetModelMapper.Map(groups).ToList();

            ViewBag.Dormitories = responseModels;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDormitoryById([FromQuery] int groupId)
        {
            var dormitory = await _dormitoryService.GetById(groupId);

            ViewBag.DormitoryRooms = _dormitoryRoomGetModelMapper.Map(dormitory.Rooms).ToList();

            return View("DormitoryDetailedView", _dormitoryGetModelMapper.Map(dormitory));
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateDormitory([FromQuery] bool add, [FromQuery] int? groupId)
        {
            var dormitoryRooms = await _dormitoryRoomService.GetAll();
            var selectedDormitoryRooms = _dormitoryRoomSelectModelMapper.Map(dormitoryRooms).ToList();

            await _viewBagDataProvider.InitFacultiesAndSpecialities(ViewBag);

            DormitoryPostModel model;

            if (add)
            {
                model = new DormitoryPostModel();

                ViewBag.Header = ControllerConstants.AddDormitoryHeader;
            }
            else
            {
                var group = await _dormitoryService.GetById(groupId.GetValueOrDefault());
                model = _dormitoryPostModelMapper.Map(group);

                foreach (var dormitoryRoom in selectedDormitoryRooms)
                {
                    if (model.DormitoryRooms.Contains(dormitoryRoom.DormitoryRoomId))
                        dormitoryRoom.Checked = true;
                }

                ViewBag.Header = ControllerConstants.UpdateDormitoryHeader;
            }

            ViewBag.DormitoryRooms = dormitoryRooms;
            ViewBag.ReadOnlySelectDormitoryRooms = false;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDormitory(
            [FromBody] DormitoryPostModel groupPostModel,
            [FromQuery] bool add = true)
        {
            var group = _dormitoryMapper.Map(groupPostModel);

            if (add)
                await _dormitoryService.AddAsync(group);
            else
                await _dormitoryService.UpdateAsync(group);

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteDormitory([FromQuery] int groupId)
        {
            await _dormitoryService.DeleteAsync(groupId);
            return Ok();
        }
    }
}