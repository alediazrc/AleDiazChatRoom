using ChatRoomMessages.ChatObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;

namespace ChatRoomMessages.DAL
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public MessageRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<List<Message>> GetMessages()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var messages = context.Messages.Take(50)
                        .OrderByDescending(x => x.CreateDate).ToList();
                    return messages;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> SaveMessage(Message message)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var existingUser = context.Users.FirstOrDefault(x => x.Name == message.Username);
                    if (existingUser == null)
                    {
                        existingUser = new User();
                        existingUser.Id = await CreateNewUser(message.Username);

                    }
                    message.UserId = existingUser.Id;
                    message.CreateDate = DateTime.UtcNow;
                    var result = await context.SaveChangesAsync();
                    return result;
                }

            }
            catch (Exception ex)
            {
                var exceptionMessage = ex.Message;
                return 0;

            }
        }
        private async Task<int> CreateNewUser(string userName)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Users.Add(new User
                {
                    Name = userName,
                    CreateDate = DateTime.UtcNow
                });
                var result = await context.SaveChangesAsync();
                return result;
            }
        }
    }
}
