using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pangul.Services
{
    public class HealthChecker : IHealthChecker
    {
        private static readonly HttpClient HttpClient = new HttpClient();

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

                result.Add(new HealthStatus(url, IsDown(httpResponseMessage), (int?) httpResponseMessage?.StatusCode,
                    DateTime.Now));
            }

            return result;
        }

        private bool IsDown(HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage == null;
        }
    }
}