using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace DataLayer.Repository.Class;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BackupContext context) : base(context)
    {
        
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await GetAll().FirstAsync(x => x.Id == id);
        return user;
    }
}