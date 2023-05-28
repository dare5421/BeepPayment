using BeepPayment.ConsumeAPI.Models.Dto;

namespace BeepPayment.ConsumeAPI.Services.IService;

public interface IBeepPayoutService
{
    public Task<T> PostPayment<T>(PaymentPacketDto packet);
    Task<T> QueryBill<T>(QueryBillDto packet);
}