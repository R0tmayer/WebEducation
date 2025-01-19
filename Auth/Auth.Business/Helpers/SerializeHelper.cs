using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth.Business.Helpers;

public static class SerializeHelper
{
    private static readonly DefaultContractResolver _contractResolver = new()
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };

    public static string SerializeObject(object obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ContractResolver = _contractResolver,
            Formatting = Formatting.Indented
        });
    }
}