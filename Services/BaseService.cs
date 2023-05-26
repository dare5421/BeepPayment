using System.Text;
using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Services.IService;
using BeepPayment.ConsumeAPI.Utility;
using Newtonsoft.Json;

namespace BeepPayment.ConsumeAPI.Services;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory httpClient;
    
    
    public APIResponse ApiResponse { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        this.ApiResponse = new APIResponse();
        this.httpClient = httpClient;
    }
    
    public async Task<T> SendAsync<T>(APIRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient("BeepAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.Data != null)
            {
                var str = JsonConvert.SerializeObject(apiRequest.Data);
                message.Content = new StringContent(JsonConvert 
                    .SerializeObject(apiRequest.Data),Encoding.UTF8,"application/json");
            }

            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break; 
            }

            HttpResponseMessage httpResponseMessage = null;
            httpResponseMessage = await client.SendAsync(message);

            var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<T>(apiContent);

            return apiResponse;

        }
        catch (Exception e)
        {
            var dto = new APIResponse()
            {
                ErrorMessages = new List<string>{Convert.ToString(e.Message)},
                IsSuccess = false
            };
            var res = JsonConvert.SerializeObject(dto);
            var apiResponse = JsonConvert.DeserializeObject<T>(res);
            return apiResponse;
        }
    }
}