using AutoMapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pangul.Services
{
    public class HealthChecker : IHealthChecker
    {
        private readonly IMapper _mapper;
        private static readonly HttpClient HttpClient = new HttpClient();

        public HealthChecker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<HealthStatus>> Check(IEnumerable<string> urls)
        {
            var result = new List<HealthStatus>();
            foreach (var url in urls)
            {
                HttpResponseMessage httpResponseMessage = default;
                try
                {
                    httpResponseMessage = await HttpClient.GetAsync(url);
                }
                catch
                {
                }

                HealthStatus healthStatus = _mapper.Map<HealthStatus>(httpResponseMessage, opt =>
                    opt.Items["url"] = url);

                result.Add(healthStatus);
            }

            return result;
        }
    }
}