using System;

namespace Pangul.Services.HttpResult
{
    public class Failed : OperationResult
    {
        public Failed(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, isDown, statusCode, now)
        {
        }
        public override string ToString() => nameof(Failed);
    }
}