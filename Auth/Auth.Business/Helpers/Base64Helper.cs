using System.Text;

namespace Auth.Business.Helpers;

public static class Base64Helper
{
    /// <summary>
    /// From string to Base64Url
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string Base64UrlEncode(string plainText)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        return Base64UrlEncode(bytes);
    }

    /// <summary>
    /// From bytes to Base64Url
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string Base64UrlEncode(byte[] bytes)
    {
        var base64 = Convert.ToBase64String(bytes);
        var base64url = base64.TrimEnd('=').Replace('+', '-').Replace('/', '_');
        return base64url;
    }

    public static string Base64UrlDecode(string encodedString)
    {
        string base64 = encodedString.Replace('_', '/').Replace('-', '+');

        switch(base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        byte[] bytes = Convert.FromBase64String(base64);
        string originalText = Encoding.ASCII.GetString(bytes);
        return originalText;
    }
}