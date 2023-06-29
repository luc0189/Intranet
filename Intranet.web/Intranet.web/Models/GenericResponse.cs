namespace Intranet.web.Models
{
    public class GenericResponse
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
