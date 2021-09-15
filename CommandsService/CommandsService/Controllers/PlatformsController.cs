using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController: ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult Test()
        {
            Console.WriteLine("--> Inbound test post # Command Service");
            
            return Ok("--> Test inbound from platforms controller");
        }
    }
}