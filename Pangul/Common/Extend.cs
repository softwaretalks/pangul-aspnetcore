using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Pangul.Services;

namespace Pangul.Common
{
    public static class ExceptionExtend
    {
        public static bool IsHostNotFound(this HttpRequestException exception) =>
            (exception.InnerException as SocketException)?.SocketErrorCode == SocketError.HostNotFound;
        public static bool IsConnectionAborted(this SocketException exception) =>
            exception.SocketErrorCode == SocketError.ConnectionAborted;
    }

    public static class UrlsExtend
    {
     
        public static async Task<List<OperationResult>> ForEach(this IEnumerable<IUrl> urls,
            Func<IUrl, Task<OperationResult>> func)
        {
            List<OperationResult> results = new List<OperationResult>();
            foreach (var url in urls)
            {
                var e = await func(url);
                results.Add(e);
            }

            return results;            
        }

        public static  List<HealthStatus> ToReport(this IEnumerable<OperationResult> results) =>
            results.Select( x => x.Report()).ToList();

    }
}