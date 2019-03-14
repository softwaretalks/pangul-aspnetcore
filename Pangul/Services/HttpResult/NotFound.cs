using System;

namespace Pangul.Services.HttpResult
{
    public class NotFound : Failed
    {

        public NotFound(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, statusCode, now, isDown)
        {

        }
        public override string ToString() =>
            nameof(NotFound);
    }
}