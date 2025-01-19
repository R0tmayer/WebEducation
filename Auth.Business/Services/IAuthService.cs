using Auth.Business.Models;

namespace Auth.Business.Services;

public interface IAuthService
{
    string Register(string login, string password);
    string Login(string login, string password);
    string GenerateJwt(JwtHeader header, JwtPayload payload, string secretKey);
    string ValidateJwt(string jwt);
}