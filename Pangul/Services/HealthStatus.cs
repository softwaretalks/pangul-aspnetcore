using System;


namespace Pangul.Services
{

    public class HealthStatus
    {
        public HealthStatus(string url, string urlStatus, int? statusCode, DateTime requestTime)
        {
            Url = url;
            UrlStatus = urlStatus;
            StatusCode = statusCode;
            RequestTime = requestTime.ToString();
        }

        public string Url { get; }

        public string UrlStatus { get; }

        public int? StatusCode { get; }

        public string RequestTime { get; }
    }

}