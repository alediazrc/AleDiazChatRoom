using AleDiazChatRoom.ChatObjects;
using AleDiazChatRoom.Constant;
using AleDiazChatRoom.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace AleDiazChatRoom.Pages
{
    public partial class ChatRoom
    {
        [Inject]
        protected  IBotService BotService { get; set; }
        [Inject]
        protected IChatHubService  ChatService { get; set; }
        public MessageDto SentMessage { get; set; }
        // flag to indicate chat status
        private bool _isChatting = false;

        // name of the user who will be chatting
        private string _username;

        // on-screen message
        private string _message;

        // new message input
        private string _newMessage;

        // list of messages in chat
        private List<MessageDto> _messages = new List<MessageDto>();

        private string _hubUrl;
        private bool isCommand { get; set; }
        private HubConnection _hubConnection;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _messages = await ChatService.GetMessages();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
      
        public async Task Chat()
        {
            // check username is valid
            if (string.IsNullOrWhiteSpace(_username))
            {
                _message = "Please enter a name";
                return;
            };

            try
            {
                // Start chatting and force refresh UI.
                _isChatting = true;
                await Task.Delay(1);

                // Create the chat client
                string baseUrl = navigationManager.BaseUri;

                _hubUrl = baseUrl.TrimEnd('/') + ChatRoomConstants.HubUrl;

                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_hubUrl)
                    .Build();

                _hubConnection.On<string, string>("Broadcast", BroadcastMessage);

                await _hubConnection.StartAsync();

                await SendAsync($"[Notice] {_username} joined chat room.");
            }
            catch (Exception e)
            {
                _message = $"ERROR: Failed to start chat client: {e.Message}";
                _isChatting = false;
            }
        }

        private void BroadcastMessage(string name, string message)
        {
            bool isMine = name.Equals(_username, StringComparison.OrdinalIgnoreCase);

            _messages.Add(new MessageDto(name, message, isMine));

            // Inform blazor the UI needs updating
            InvokeAsync(StateHasChanged);
        }

        private async Task DisconnectAsync()
        {
            if (_isChatting)
            {
                await SendAsync($"[Notice] {_username} left chat room.");

                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();

                _hubConnection = null;
                _isChatting = false;
            }
        }
        private async Task CommandMessageDetected(string message)
        {
            var messageRecieved = await BotService.SendMessagesToBot(message);
            if (messageRecieved != null)
            {
                await _hubConnection.SendAsync("Broadcast", ChatRoomConstants.BotUserName, messageRecieved);

            }
        }
       
        private async Task SendAsync(string message, bool isCommand =false)
        {
            if (_isChatting && !string.IsNullOrWhiteSpace(message))
            {
                await _hubConnection.SendAsync("Broadcast", isCommand? ChatRoomConstants.BotUserName : _username ,message);
                if(_newMessage != null)
                await ChatService.SaveMessage(_messages.Last());
                _newMessage = string.Empty;
                
               
                if (message.Contains("/stock="))
                {
                    await SendAsync("Message recieved", true);
                    await CommandMessageDetected(message);
                }
            }
            
          
        }

        
    }
}
