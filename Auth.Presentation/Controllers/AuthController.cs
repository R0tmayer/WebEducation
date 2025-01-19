using Auth.Business.Services;
using Auth.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Presentation.Controllers;

[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [Route("register")]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        var jwt = _authService.Register(registerDto.Login, registerDto.Password);
        return Ok();
    }
    
    [Route("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        _authService.Login(loginDto.Login, loginDto.Password);
        return Ok();
    }
}