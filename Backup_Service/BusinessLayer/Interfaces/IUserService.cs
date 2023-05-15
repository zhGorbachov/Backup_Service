using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IUserService
{
    public Task<UserModel> GetUserModelByIdAsync(int id);
    public Task<User> AddUserAsync(UserModel userModel);
    public Task<User> UpdateUserAsync(UserModel userModel);
    public Task DeleteUserAsync(int id);
    public IQueryable GetAllUsers();
}