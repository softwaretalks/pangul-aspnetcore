using System;

namespace Pangul.Services.HttpResult
{
    public class UriNotFound : Failed
    {
        public UriNotFound(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, statusCode, now, isDown)
        {

        }

        public override string ToString()
        {
            return nameof(UriNotFound);
        }
    }
}