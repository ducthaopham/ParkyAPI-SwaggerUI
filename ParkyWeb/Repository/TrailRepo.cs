using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using System.Net.Http;

namespace ParkyWeb.Repository
{
    public class TrailRepo : GenericRepo<Trail>, ITrailRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        public TrailRepo(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
