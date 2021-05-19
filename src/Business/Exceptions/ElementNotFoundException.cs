using System;
using System.Runtime.Serialization;

namespace PlaneTicketReservationSystem.Business.Exceptions
{
    [Serializable]
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException()
        {
        }

        public ElementNotFoundException(string message) : base(message)
        {
        }

        public ElementNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ElementNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
