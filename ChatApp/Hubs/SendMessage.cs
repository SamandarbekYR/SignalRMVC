using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class SendMessage : Hub
    {
        public async Task JoinToChat(string fullName, string connectionId)
        {
            await Clients.Others.SendAsync("SomebodyJoined", fullName, connectionId, $"{fullName} joined chat at {DateTime.Now}");
        }

        public async Task LeftFromChat(string fullName, string connectionId)
        {
            await Clients.Others.SendAsync("SomebodyLeft", fullName, connectionId, $"{fullName} left chat at {DateTime.Now}");
        }

        public async Task SendMessageToAll(string fullName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",fullName ,message);
        }

        public async Task SendMessageToUser(string fullName, string message, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveDM", $"{fullName}: {message}");
        }
    }
}
