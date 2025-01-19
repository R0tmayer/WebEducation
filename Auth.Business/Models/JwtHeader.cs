namespace Auth.Business.Models;

public class JwtHeader
{
    public string Alg { get; set; } = string.Empty;
    public string Typ { get; set; } = string.Empty;
}