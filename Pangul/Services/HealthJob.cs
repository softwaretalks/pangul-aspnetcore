using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pangul.Services
{
    public class HealthJob : IHealthJob
    {
        private const string FileName = "Log.txt";

        public async Task Save(IEnumerable<HealthStatus> healthStatuses)
        {
            var result = JsonConvert.SerializeObject(healthStatuses);

            var location = Assembly.GetEntryAssembly().Location;
            var binDirectory = Path.GetDirectoryName(location);
            var filePath = Path.Combine(binDirectory, FileName);

            await File.AppendAllTextAsync(filePath, result);
        }
    }
}