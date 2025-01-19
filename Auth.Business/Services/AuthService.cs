using System.Security.Cryptography;
using System.Text;
using Auth.Business.Helpers;
using Auth.Business.Models;
using Auth.DataAccess.Repositories;
using Auth.Domain.Models;

namespace Auth.Business.Services;

public class AuthService : IAuthService
{
    private const string SECRET_KEY = "secret_key_123";
    private const int EXPIRATION_DURATION_HOURS = 1;
    private readonly JwtHeader JWT_HEADER = new()
    {
        Alg = "HS256",
        Typ = "JWT"
    };

    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string Register(string login, string password)
    {
        var existingUser = _userRepository.GetByLogin(login);

        if (existingUser is not null)
        {
            throw new Exception($"User with login {login} already exists");
        }
        
        var salt = GenerateSalt();

        var user = new User
        {
            Login = login,
            PasswordHash = GenerateHashPassword(password, salt),
            Salt = salt
        };

        var createdUser = _userRepository.Create(user);
        
        DateTime createdAt = DateTime.Now;
        TimeSpan expirationDuration = TimeSpan.FromHours(EXPIRATION_DURATION_HOURS);

        var jwtPayload = new JwtPayload(createdUser.Id, createdAt, expirationDuration);
        var jwt = GenerateJwt(JWT_HEADER, jwtPayload, SECRET_KEY);
        
        return jwt;
    }

    public string Login(string login, string password)
    {
        throw new NotImplementedException();
    }

    private string GenerateSalt(int length = 16)
    {
        var saltBytes = new byte[length];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        return Base64Helper.FromBytesToBase64(saltBytes);
    }

    private string GenerateHashPassword(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var saltedPassword = password + salt;
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            return Base64Helper.FromBytesToBase64(hashBytes);
        }
    }

    public string GenerateJwt(JwtHeader header, JwtPayload payload, string secretKey)
    {
        var headerJson = SerializeHelper.SerializeObject(header); // получили строковый json
        var payloadJson = SerializeHelper.SerializeObject(payload); // получили строковый json

        var headerBase64 = Base64Helper.FromStringToBase64(headerJson);
        var payloadBase64 = Base64Helper.FromStringToBase64(payloadJson);

        string signature = GenerateSignature(headerBase64, payloadBase64, secretKey);

        return $"{headerBase64}.{payloadBase64}.{signature}";
    }

    private string GenerateSignature(string base64Header, string base64Payload, string secretKey)
    {
        var secketKeyBytes = Encoding.UTF8.GetBytes(secretKey);

        var cipherText = $"{base64Header}.{base64Payload}";
        var cipherBytes = Encoding.UTF8.GetBytes(cipherText);

        var sha256 = new HMACSHA256(secketKeyBytes); // сущность подписи
        byte[] hashBytes = sha256.ComputeHash(cipherBytes); // подпись { Header + Payload } в байтах
        string hashBase64 = Base64Helper.FromBytesToBase64(hashBytes); // подпись { Header + Payload } в Base64

        return hashBase64;
    }

    public string ValidateJwt(string jwt)
    {
        throw new NotImplementedException();
    }
}