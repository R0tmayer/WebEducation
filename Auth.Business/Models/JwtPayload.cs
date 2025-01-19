namespace Auth.Business.Models;

public class JwtPayload
{
    public Dictionary<string, string> Claims { get; } = new();

    public JwtPayload(int userId, DateTime createdAt, TimeSpan expirationDuration)
    {
        Claims.Add("sub", userId.ToString());
        
        // DateTimeOffset хранит дату и время с учётом смещения от UTC,
        // что позволяет избежать проблем с часовыми поясами и корректно обрабатывать время в разных регионах.
        
        // Время создания токена (iat) - текущее время
        Claims.Add("iat", ((DateTimeOffset)createdAt).ToUnixTimeSeconds().ToString());

        // Время истечения токена (exp) - текущее время + продолжительность истечения
        var expirationTime = createdAt.Add(expirationDuration);
        Claims.Add("exp", ((DateTimeOffset)expirationTime).ToUnixTimeSeconds().ToString());
    }
}