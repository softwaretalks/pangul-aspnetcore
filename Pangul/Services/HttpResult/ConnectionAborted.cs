using System;

namespace Pangul.Services.HttpResult
{
    public class ConnectionAborted : Failed
    {
        public ConnectionAborted(string value, int? statusCode, DateTime now, bool isDown = true) : base(value, statusCode, now, isDown)
        {
        }

        public override string ToString() =>
            nameof(ConnectionAborted);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0cc8d4295b245a564bfde2daf27fd26a18a41a4c
