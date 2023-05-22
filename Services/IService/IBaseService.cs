using BeepPayment.ConsumeAPI.Models;

namespace BeepPayment.ConsumeAPI.Services.IService;

public interface IBaseService
{
    public APIResponse ApiResponse { get; set; }
    Task<T> SendAsync<T>(APIRequest apiRequest);
}