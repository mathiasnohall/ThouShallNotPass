using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ThouShallNotPass.Services
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string url);

        Task PostAsync<T>(string url, T body);
    }

    public class HttpClient : IHttpClient
    {
        public HttpClient()
        {

        }

        public async Task<T> GetAsync<T>(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = await client.GetAsync(url);
                using (var streamReader = new StreamReader(await request.Content.ReadAsStreamAsync()))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();

                        return serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }

        public Task PostAsync<T>(string url, T body)
        {
            throw new NotImplementedException();
        }
    }
}
