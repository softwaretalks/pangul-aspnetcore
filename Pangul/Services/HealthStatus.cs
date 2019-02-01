namespace Pangul.Services
{
    public class HealthStatus
    {
        public HealthStatus(string url, bool isDown, int? statusCode)
        {
            Url = url;
            IsDown = isDown;
            StatusCode = statusCode;
        }

        public string Url { get; }

        public bool IsDown { get; }

        public int? StatusCode { get; }
    }
}