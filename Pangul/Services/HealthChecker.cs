using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Pangul.Common;

namespace Pangul.Services
{
    public class HealthChecker : IHealthChecker
    {


        public async Task<List<HealthStatus>> Check(Urls urls)
        {
            var results =await urls
                .GetResponses()
                ;
            return results.ToReport();

        }


        public async Task<List<HealthStatus>> UnavailableUrls(Urls urls)
        {
            var results = await urls
                .GetUnAvailable();
            return results.ToReport();
        }
    }
}