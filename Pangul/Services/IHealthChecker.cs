using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pangul.Services
{
    public interface IHealthChecker
    {
        Task<List<HealthStatus>> Check(IEnumerable<string> urls);
    }
}