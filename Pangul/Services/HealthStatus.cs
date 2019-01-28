namespace Pangul.Services
{
    public class HealthStatus
    {
        public HealthStatus(string url, bool isDown)
        {
            Url = url;
            IsDown = isDown;
        }

        public string Url { get; }

        public bool IsDown { get; }
    }
}