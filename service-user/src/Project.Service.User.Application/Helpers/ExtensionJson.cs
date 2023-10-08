using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Project.Service.User.Application.Helpers
{
    public static class ExtensionJson
    {
        public static string ToJsonStringCamelcase<T>(this T obj) where T : class
        {
            var jsonOption = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, jsonOption);
        }
    }
}
