using System;

namespace Pangul.Services.HttpResult
{
    public class Success : OperationResult
    {
        public Success(string value, int? statusCode, DateTime now, bool isDown = false) : base(value, isDown, statusCode, now)
        {
        }
        public override string ToString() => nameof(Success);
    }
}