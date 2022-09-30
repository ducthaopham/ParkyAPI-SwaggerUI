using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkyWeb.Repository
{
    public class NationalParkRepo : GenericRepo<NationalPark>, INationalParkRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        public NationalParkRepo(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
