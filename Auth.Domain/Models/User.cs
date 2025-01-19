namespace Auth.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; } // nullable потому что при создании модели мы не знаем UpdatedAt
    public DateTime? CreatedAt { get; set; } // nullable потому что при создании модели мы не знаем CreatedAt
}