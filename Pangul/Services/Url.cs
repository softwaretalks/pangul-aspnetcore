using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Pangul.Common;
using Pangul.Services.HttpResult;

namespace Pangul.Services
{
    public class Url : IUrl
    {
        private readonly IHttpClientFactory _clientFactory;

        private string Uri { get; }

        private string RequestUri { get; }

        private string Value => this.Uri + this.RequestUri;

        public Url(string uri, IHttpClientFactory clientFactory, string requestUri = "")
        {
            if (string.IsNullOrEmpty(uri))
            {
                uri = "";
            }

            _clientFactory = clientFactory;
            Uri = uri;
            RequestUri = requestUri;
          
        }

        public async Task<OperationResult> GetResponse()
        {
            HttpResponseMessage httpResponseMessage = default;
            try
            {
                var httpClient = _clientFactory.CreateClient(Uri);

                httpResponseMessage = await httpClient.GetAsync(Value, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);
                if (httpResponseMessage.IsSuccessStatusCode)
                    return new Success(Value,
                        (int?) httpResponseMessage?.StatusCode,
                        DateTime.Now);

                return new Failed(Value,404, DateTime.Now, true);
            }
            catch (UriFormatException )
            {
                return new UriNotFound(Value, 0, DateTime.Now);
            }


            catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
            {
                return new NetworkTimeout(Value,
                    (int?) httpResponseMessage?.StatusCode,
                    DateTime.Now);
            }
            catch (SocketException ex) when (ex.IsConnectionAborted())
            {
                return new ConnectionAborted(Value,
                    10053,
                    DateTime.Now);
            }

            catch (HttpRequestException ex) when (ex.IsHostNotFound())
            {             
                return new NotFound(Value, 404,DateTime.Now);
            }
            catch (InvalidOperationException)
            {
                return new UriNotFound(Value, 0, DateTime.Now);
            }

        }

        public override string ToString() => this.Value;
    }

}



