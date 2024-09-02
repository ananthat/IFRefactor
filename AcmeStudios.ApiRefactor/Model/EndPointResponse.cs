using System.Net;

namespace AcmeStudios.ApiRefactor.Model
{
    public class EndPointResponse<T>
    {
        public EndPointResponse()
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }

        public bool IsSuccess { get; set; } = false;

        public string CustomMessage { get; set; } = null;
    }
}
