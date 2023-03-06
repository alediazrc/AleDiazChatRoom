using AleDiazChatRoom.ChatObjects;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Options;

namespace AleDiazChatRoom.DAL
{
    public partial class MessageRepository : IMessageRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        [Inject]
        private IMapper _mapper { get; set; }
        public MessageRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task<List<MessageDto>> GetMessages()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var messages = _mapper.Map<List<MessageDto>>( context.Messages.Take(50)
                        .OrderByDescending(x => x.CreateDate).ToList());
                    return messages;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

       

        public async Task<int> SaveMessage(MessageDto message)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var existingUser = context.Users.FirstOrDefault(x => x.Name == message.Username);
                    if (existingUser ==null)
                    {
                        existingUser = new User();
                       existingUser.Id = await CreateNewUser(message.Username);

                    }
                    
                    context.Messages.Add(new Message
                    {
                        Body = message.Body,
                        Mine = message.Mine,
                        UserId = existingUser.Id,
                        IsCommand= message.IsCommand,
                        Username = message.Username,
                        CreateDate = DateTime.UtcNow

                    });
                    var result = await context.SaveChangesAsync();
                    return result;
                }


            }
            catch (Exception ex )
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
