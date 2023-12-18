using Nox.Exceptions;
using System.Net;

namespace ClientApi.Application.Exceptions
{
    [Serializable]
    public class CountryNameInvalid : Exception, IApplicationException
    {
        public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

        public string ErrorCode => "invalid_countryname";

        public required object ErrorDetails { get; set; }

        public CountryNameInvalid()
        {
        }

        public CountryNameInvalid(string message)
            : base(message)
        {
        }

        public CountryNameInvalid(string message, Exception inner)
            : base(message, inner)
        {
        }
       
    }
}
