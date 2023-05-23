using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Models.Dto;
using BeepPayment.ConsumeAPI.Services.IService;
using BeepPayment.ConsumeAPI.Utility;

namespace BeepPayment.ConsumeAPI.Services;

public class BeepPayoutService : BaseService, IBeepPayoutService
{
    private string beepUrl;
    private readonly IHttpClientFactory _httpClientFactory;
    public BeepPayoutService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _httpClientFactory = httpClient;
        beepUrl = "https://beep2.cellulant.africa:9001/paymentRouter/JSONV2/";
    }

    public Task<T> PostPayment<T>(PaymentPacketDto packet)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = packet,
            Url = beepUrl
        });
    }
}