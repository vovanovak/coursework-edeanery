
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EDeanery.PL.Controllers
{
    public class DormitoryRoomController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult> GetDormitoryRoomById([FromQuery] int groupId)
        {
            return null;
        }
    }
}