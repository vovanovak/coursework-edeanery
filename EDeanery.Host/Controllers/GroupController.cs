using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Host.Constants;
using EDeanery.Host.Models;
using EDeanery.Host.Providers;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.Host.Controllers
{
    public class GroupController : Controller
    {
        private readonly IMapper<Group, GroupGetModel> _groupGetModelMapper;
        private readonly IMapper<Group, GroupGetDetailedModel> _groupGetDetailedModelMapper;
        private readonly IMapper<GroupPostModel, Group> _groupMapper;
        private readonly IMapper<Group, GroupPostModel> _groupPostModelMapper;
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;
        private readonly IMapper<Student, StudentSelectModel> _studentSelectModelMapper;
        private readonly IViewBagDataProvider _viewBagDataProvider;
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupController(
            IMapper<Group, GroupGetModel> groupGetModelMapper,
            IMapper<Group, GroupGetDetailedModel> groupGetDetailedMapper,
            IMapper<GroupPostModel, Group> groupMapper,
            IMapper<Group, GroupPostModel> groupPostModelMapper,
            IMapper<Student, StudentSelectModel> studentSelectModelMapper,
            IMapper<Student, StudentGetModel> studentGetModelMapper,
            IGroupService groupService,
            IStudentService studentService,
            IViewBagDataProvider viewBagDataProvider)
        {
            _groupGetModelMapper = groupGetModelMapper;
            _groupGetDetailedModelMapper = groupGetDetailedMapper;
            _groupMapper = groupMapper;
            _groupPostModelMapper = groupPostModelMapper;
            _studentSelectModelMapper = studentSelectModelMapper;
            _studentGetModelMapper = studentGetModelMapper;
            _groupService = groupService;
            _studentService = studentService;
            _viewBagDataProvider = viewBagDataProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetAll();
            var responseModels = _groupGetModelMapper.Map(groups).ToList();

            ViewBag.Groups = responseModels;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetGroupById([FromQuery] int groupId)
        {
            var group = await _groupService.GetById(groupId);

            ViewBag.Students = _studentGetModelMapper.Map(group.Students).ToList();

            return View("GroupDetailedView", _groupGetDetailedModelMapper.Map(group));
        }

        [HttpGet]
        public async Task<ActionResult> AddOrUpdateGroup([FromQuery] bool add, [FromQuery] int? groupId)
        {
            var students = await _studentService.GetAll();
            var selectStudents = _studentSelectModelMapper.Map(students).ToList();

            await _viewBagDataProvider.InitFacultiesAndSpecialities(ViewBag);

            GroupPostModel model;

            if (add)
            {
                model = new GroupPostModel();

                ViewBag.Header = ControllerConstants.AddGroupHeader;
            }
            else
            {
                var group = await _groupService.GetById(groupId.GetValueOrDefault());
                model = _groupPostModelMapper.Map(group);

                foreach (var student in selectStudents)
                {
                    if (model.Students.Contains(student.StudentId))
                        student.Checked = true;
                }

                ViewBag.Header = ControllerConstants.UpdateGroupHeader;
            }

            ViewBag.Students = selectStudents;
            ViewBag.ReadOnlySelectStudents = false;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateGroup(
            [FromBody] GroupPostModel groupPostModel,
            [FromQuery] bool add = true)
        {
            var group = _groupMapper.Map(groupPostModel);

            if (add)
                await _groupService.AddAsync(group);
            else
                await _groupService.UpdateAsync(group);

            await _groupService.SetStudentsFromGroup(group.GroupId, (IReadOnlyCollection<int>) groupPostModel.Students);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult CheckGroupName([FromQuery] string name)
        {
            var isValid = _groupService.IsGroupNameUnique(name);
            return Json(new {IsValid = isValid, Message = ValidatorConstants.DormitoryNameIsNotUnique});
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGroup([FromQuery] int groupId)
        {
            await _groupService.DeleteAsync(groupId);
            return Ok();
        }
    }
}