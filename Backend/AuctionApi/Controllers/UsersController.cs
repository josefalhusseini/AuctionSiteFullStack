using Microsoft.AspNetCore.Mvc;
using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.DTOs;

namespace AuctionApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };

        return Ok(await _service.RegisterAsync(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var userId = await _service.LoginAsync(dto.Email, dto.Password);

        if (userId == null)
            return Unauthorized("Fel email eller lösenord");

        return Ok(userId);
    }
}