using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient client, string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await client.GetAsync(url, cancellationToken).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();


            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
