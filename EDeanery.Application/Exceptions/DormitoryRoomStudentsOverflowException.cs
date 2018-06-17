using System;
using System.Runtime.Serialization;

namespace EDeanery.Application.Exceptions
{
    public class DormitoryRoomStudentsOverflowException : ApplicationException
    {
        public DormitoryRoomStudentsOverflowException()
        {
        }

        public DormitoryRoomStudentsOverflowException(string message) : base(message)
        {
        }

        public DormitoryRoomStudentsOverflowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DormitoryRoomStudentsOverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}