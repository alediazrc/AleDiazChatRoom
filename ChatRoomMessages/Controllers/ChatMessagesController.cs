using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomMessages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : ControllerBase
    {
        [HttpGet]
        public string GetStoredMessages()
        {
            return "Im a result";
        }
    }
}
