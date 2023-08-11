using System.Net;

namespace GrindRailsAPI.Shared.DTOs
{
    public class ServiceResponseDTO<T>
    {
        public T GenericData { get; set; }
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
