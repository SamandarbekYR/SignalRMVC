using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.Hubs
{
    public class SendMessage : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(user, message);
        }
    }
}
