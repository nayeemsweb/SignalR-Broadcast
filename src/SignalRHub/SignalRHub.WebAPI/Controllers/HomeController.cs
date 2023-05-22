using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.WebAPI.Hubs;
using SignalRHub.WebAPI.Models;

namespace SignalRHub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;

        public HomeController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("PushEmployee")]
        public IActionResult PushEmployee(int id, string name, string address)
        {
            var employee = new Employee();
            employee.Id = id;
            employee.Name = name;
            employee.Address = address;

            _hubContext.Clients.All.SendAsync("ReceiveEmployee", employee);

            return Ok("Done");
        }

        [HttpGet]
        [Route("PushMessage")]
        public IActionResult PushMessage(string message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", message);

            return Ok("Done");
        }
    }
}
