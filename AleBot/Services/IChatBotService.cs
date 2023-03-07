using AleBot.ChatObjects;
using System.Net.Http;
using System.Threading.Tasks;

namespace AleBot.Services
{
    public interface IChatBotService
    {
        public Task<HttpResponseMessage> SaveMessage(string message);

    }
}
