namespace Pangul.Models
{
    public class UrlResult
    {
        public int Id { get; }

        public string Url { get; }

        public UrlResult(int id, string url)
        {
            Id = id;
            Url = url;
        }
    }
}
