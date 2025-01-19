using System.Text;

namespace Auth.Business.Helpers;

public static class Base64Helper
{
    public static string FromStringToBase64(string plainText)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(bytes);
    }

    public static string FromBytesToBase64(byte[] bytes)
    {
        var base64 = Convert.ToBase64String(bytes);
        return base64;
    }
}