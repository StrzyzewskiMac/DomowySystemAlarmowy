using System;
using System.Runtime.Serialization;

namespace SystemCore.Exceptions
{
    /// <summary>
    /// Wyjątek rzucany, gdy użytkownik próbuje uzyskać dostęp do funkcjonalności spoza zbioru jego przywilejów.
    /// </summary>
    public class AccessDeniedException : UnauthorizedAccessException
    {
        public AccessDeniedException() { }

        public AccessDeniedException(string message) : base(message) { }

        public AccessDeniedException(string message, Exception inner) : base(message, inner) { }

        protected AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
