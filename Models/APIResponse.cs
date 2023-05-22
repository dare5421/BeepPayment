using System.Net;

namespace BeepPayment.ConsumeAPI.Models;

public class APIResponse
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public bool IsSuccess { get; set; } = true;
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }
}