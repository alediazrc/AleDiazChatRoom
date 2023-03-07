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
        public IActionResult SaveMessage( string StockCode)
        {
            try
            {
                
                chatService.SaveMessage(StockCode);
                return Ok("Saved");

            }
            catch (Exception)
            {
                return NotFound();               
            }
            
        }
    }
}
