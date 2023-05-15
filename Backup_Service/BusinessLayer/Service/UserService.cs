using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _contextUser;
    private readonly Mapper _mapper;
    public UserService(IUserRepository context, Mapper mapper) 
    {
        _contextUser = context;
        _mapper = mapper;
    }

    public async Task<UserModel> GetUserModelByIdAsync(int id)
    {
        var user = await _contextUser.GetUserByIdAsync(id);
        return _mapper.Map<UserModel>(user);
    }

    public async Task<User> AddUserAsync(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);
        return await _contextUser.AddAsync(user);
    }

    public async Task<User> UpdateUserAsync(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);
        return await _contextUser.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _contextUser.DeleteAsync(id);
    }

    public IQueryable GetAllUsers()
    {
        var accounts = _contextUser.GetAll();
        return _mapper.Map<IQueryable<AccountModel>>(accounts);
    }
}