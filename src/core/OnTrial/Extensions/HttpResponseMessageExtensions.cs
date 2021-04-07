using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace OnTrial
{
    public static class HttpResponseMessageExtensions
    {
        public static T ToObject<T>(this HttpResponseMessage pMsg)
        {
            var result = pMsg.Content.ReadAsByteArrayAsync().Result;
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(result));
        }
    }
}