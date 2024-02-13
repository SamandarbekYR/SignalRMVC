using ChatApp.Models;

namespace ChatApp.DataAccessLayer.Interface
{
    public interface ISMSSender
    {
        public Task<bool> SendAsync(SMSSenderDto message);
    }
}
