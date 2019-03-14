using System;

namespace Pangul.Services.HttpResult
{
    public class ConnectionAborted : OperationResult
    {
        public ConnectionAborted(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, isDown, statusCode, now)
        {

        }
        public override string ToString() =>
            nameof(ConnectionAborted);
    }
}