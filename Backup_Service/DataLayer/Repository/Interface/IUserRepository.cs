using DataLayer.Entities;

namespace DataLayer.Repository.Interface;

public interface IUserRepository : IGenericRepository<User> 
{
    // public Task<User> GetUserByIdAsync(int id);
}