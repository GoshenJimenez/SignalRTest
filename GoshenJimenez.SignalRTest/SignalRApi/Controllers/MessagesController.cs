using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using SignalRApi.Hubs;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private IHubContext<MessageHub, IMessageHub> _messageHub;
        public MessagesController(ILogger<MessagesController> logger, IHubContext<MessageHub, IMessageHub> messageHub)
        {
            _logger = logger;
            _messageHub = messageHub;
        }

        [HttpPost]
        public JsonResult Post(MessageDto dto)
        {
            _messageHub.Clients.All.SendMessage(dto.User, dto.Message);

            return new JsonResult(dto.User + " says " + dto.Message);
        }
    }
    

}
