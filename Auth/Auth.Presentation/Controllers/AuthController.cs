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
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        var jwt = _authService.Register(registerDto.Login, registerDto.Password);
        return Ok(jwt);
    }

    [HttpPost("verify")]
    public IActionResult VerifyJwt([FromBody] string jwt)
    {
        var valid = _authService.VerifyJwt(jwt);
        return Ok(valid);
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        _authService.Login(loginDto.Login, loginDto.Password);
        return Ok();
    }
}