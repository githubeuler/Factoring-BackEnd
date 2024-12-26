using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace Factoring.Domain.Util
{
    public static class JsonHelper
    {
        public static string ToJson(this object o)
        {
            if (o == null) return "";
            var result = JsonConvert.SerializeObject(o,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
            return result;
        }

        public static T DeserializeObject<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, (JsonSerializerSettings)null);
        }

        public static readonly JsonMediaTypeFormatter CamelCaseFormatter = new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            }
        };
    }
}
