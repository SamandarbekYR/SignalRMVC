using ChatApp.Models;

namespace ChatApp.DataAccessLayer.Interface
{
    public interface IUser
    {
        Task Add(Users user);
        Task<bool> Update(Users user, string id);
        Task Delete(string id);
        Task<IEnumerable<Users>> GetAll();
    }
}
