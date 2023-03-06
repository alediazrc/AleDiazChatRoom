using ChatRoomMessages.ChatObjects;
using ChatRoomMessages.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomMessages.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : ControllerBase
    {
        [Inject]
        private IChatService chatService { get; set; }
        public ChatMessagesController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpGet]
        public string GetStoredMessages()
        {
            return "Im a result";
        }

        [HttpPost]
        public IActionResult StoredAMessage( string StockCode, Message message)
        {
            try
            {
                message.IsCommand = true;
                chatService.SaveMessage(message);
                return Ok("Saved");

            }
            catch (Exception)
            {
                return NotFound();               
            }
            
        }
    }
}
