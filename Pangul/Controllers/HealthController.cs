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

        public HealthController(IOptions<List<string>> urls, IHealthChecker healthChecker)
        {
            _urls = urls;
            _healthChecker = healthChecker;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthStatus>>> GetHealthStatus()
        {
            var result = await _healthChecker.Check(_urls.Value);

            return result;
        }
    }
}