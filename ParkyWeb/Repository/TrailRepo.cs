using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkyWeb.Repository
{
    public class TrailRepo : GenericRepo<Trail>, ITrailRepo
    {
        private readonly IHttpClientFactory _clientF;
        public TrailRepo(IHttpClientFactory clientF) : base(clientF)
        {
            _clientF = clientF;
        }
    }
}
