using System;

namespace Pangul.Services
{
    public class HealthStatus
    {
        public HealthStatus(string url, bool isDown, int? statusCode, DateTime requestTime)
        {
            Url = url;
            IsDown = isDown;
            StatusCode = statusCode;
            RequestTime = requestTime;
        }

        public string Url { get; }

        public bool IsDown { get; }

        public int? StatusCode { get; }

        public DateTime RequestTime { get; }
    }
}