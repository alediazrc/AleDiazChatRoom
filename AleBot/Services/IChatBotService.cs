using AleBot.ChatObjects;
using System.Threading.Tasks;

namespace AleBot.Services
{
    public interface IChatBotService
    {
        public Task<int> SaveMessage(string message);

    }
}
