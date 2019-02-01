using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pangul.Services
{
    public interface IHealthJob
    {
        Task Save(IEnumerable<HealthStatus> healthStatuses);
    }
}