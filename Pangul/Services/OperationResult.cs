using System;

namespace Pangul.Services
{
    public abstract class OperationResult
    {
        private readonly string _value;
        private readonly bool _isDown;
        private readonly int? _statusCode;
        private readonly DateTime _now;

        protected OperationResult(string value, bool isDown, int? statusCode, DateTime now)
        {
            _value = value;
            _isDown = isDown;
            _statusCode = statusCode;
            _now = now;
        }

        public HealthStatus Report() =>
            new HealthStatus(_value, $"Result : {ToString()}", _statusCode, _now);
    }
}