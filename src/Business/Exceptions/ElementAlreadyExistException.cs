using System;
using System.Runtime.Serialization;

namespace PlaneTicketReservationSystem.Business.Exceptions
{
    [Serializable]
    public class ElementAlreadyExistException : Exception
    {

        public ElementAlreadyExistException()
        {
        }

        public ElementAlreadyExistException(string message) : base(message)
        {
        }

        public ElementAlreadyExistException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ElementAlreadyExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
