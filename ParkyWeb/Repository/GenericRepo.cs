using Newtonsoft.Json;
using ParkyWeb.Repository.IRepository;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkyWeb.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly IHttpClientFactory _clientF;
        public GenericRepo(IHttpClientFactory clientF)
        {
            _clientF = clientF;
        }
        public async Task<bool> CreateAsync(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (obj != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");
            else
                return false;
            var client = _clientF.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url+id);
            var client = _clientF.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientF.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var jsonString = await response.Content.ReadAsStringAsync();    
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            return null;
        }

        public async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientF.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            if (obj != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");
            else
                return false;
            var client = _clientF.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
    }
}
