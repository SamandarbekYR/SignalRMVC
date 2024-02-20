using ChatApp.DataAccessLayer.Data;
using ChatApp.DataAccessLayer.Interface;
using ChatApp.Models;
using MongoDB.Driver;

namespace ChatApp.DataAccessLayer.Repositories
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _dbSet;

        public UserRepository(AppDbContext appDb)
        {
            _dbSet = appDb;
        }
        public async Task Add(Users user)
            => await _dbSet.User.InsertOneAsync(user);

        public async Task Delete(string id)
            => await _dbSet.User.DeleteOneAsync(id);
        public async Task<IEnumerable<Users>> GetAll()
            => await _dbSet.User.AsQueryable().ToListAsync();

        public async Task<bool> Update(Users user, string id)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(u => u.Id, id);
            ReplaceOneResult result = await _dbSet.User.ReplaceOneAsync(filter, user);

            return result.IsAcknowledged;
        }
    }
}
