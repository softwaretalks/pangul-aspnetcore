using System;

namespace Pangul.Services.HttpResult
{
    public class NetworkTimeout : Failed
    {
        public NetworkTimeout(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, statusCode, now, isDown)
        {

        }

        public override string ToString() => nameof(NetworkTimeout);

    }
}