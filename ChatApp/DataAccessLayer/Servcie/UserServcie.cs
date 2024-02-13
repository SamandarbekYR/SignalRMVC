using ChatApp.DataAccessLayer.Data;
using ChatApp.DataAccessLayer.Interface;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DataAccessLayer.Servcie
{
    public class UserServcie : IUser
    {
        private AppDbContext _dbContext;

        public UserServcie()
        {
            _dbContext = new AppDbContext();
        }
        public int Register(UserRegister request)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Phone == request.Phone);
            if (user != null)
            {
                return 0;
            }
            var newUser = new Users
            {
                Name = request.Name,
                Phone = request.Phone,
                Password = request.Password
            };
            _dbContext.Users.Add(newUser);
            return _dbContext.SaveChanges();
        }

        public Users Login(UserLogin request)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Phone == request.Phone);

            if (user == null)
            {
                return new Users();
            }

            if (user.Password != request.Password)
            {

               return new Users();
            }
          
            return user;
        }
        public async Task<List<Users>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}
