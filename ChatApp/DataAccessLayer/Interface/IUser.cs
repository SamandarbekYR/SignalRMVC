using ChatApp.Models;

namespace ChatApp.DataAccessLayer.Interface
{
    public interface IUser
    {
        int Register(UserRegister users);
        Users Login(UserLogin user);
        Task<List<Users>> GetUsers();
    }
}
