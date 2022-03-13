using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using message_api.Services;

namespace Microservice_Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public void Post([FromBody] string payload)
        {
            _messageService.Enqueue(payload);
        }
    }
}
