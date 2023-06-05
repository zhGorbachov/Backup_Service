using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers;

public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUserModelAsync(UserDTO userDto)
    {
        var userModel = _mapper.Map<UserModel>(userDto);
        var user = await _userService.AddUserAsync(userModel);
        return Ok(user);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUserModelAsync(UserDTO userDto, int id)
    {
        var userModel = _mapper.Map<UserModel>(userDto);
        var user = await _userService.UpdateUserAsync(userModel, id);
        return Ok(user);
    }
    
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUserModelAsync(int id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }
    
    [HttpGet("GetAllUsers")]
    public IActionResult GetAllUsersModel()
    {
        var userModels = _userService.GetAllUsers();
        var usersDto = _mapper.ProjectTo<UserDTO>(userModels);
        return Ok(usersDto);
    }
    
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var userModel = await _userService.GetUserModelByIdAsync(id);
        var userDto = _mapper.Map<UserDTO>(userModel);
        return Ok(userDto);
    }
}