using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pangul.Services;

namespace Pangul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IOptions<List<string>> _urls;
        private readonly IHealthChecker _healthChecker;
        private readonly IHealthJob _healthJob;

        public HealthController(IOptions<List<string>> urls, IHealthChecker healthChecker, IHealthJob healthJob)
        {
            _urls = urls;
            _healthChecker = healthChecker;
            _healthJob = healthJob;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthStatus>>> GetHealthStatus()
        {
            var healthStatuses = await _healthChecker.Check(_urls.Value);

            await _healthJob.Save(healthStatuses);

            return healthStatuses;
        }
    }
}