using System.Net;

namespace CQRS_Pattern.Exceptions
{
    public class NotFoundException: CustomException
    {
        public NotFoundException(string message)
            : base(message, null, HttpStatusCode.NotFound)
        {
        }
    }
}
