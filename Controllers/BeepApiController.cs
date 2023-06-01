using System.Net;
using BeepPayment.ConsumeAPI.Data;
using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Models.Dto;
using BeepPayment.ConsumeAPI.Services.IService;
using BeepPayment.ConsumeAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeepPayment.ConsumeAPI.Controllers;

[ApiController]
[Route("api/BeepAPI")]
public class BeepApiController : ControllerBase
{

    private APIResponse _response;
    // private readonly IRepository<APIResponse> _dbBeep;
    //private readonly ApplicationDbContext _db;
    private readonly IBeepPayoutService _beepService;

    public BeepApiController(IBeepPayoutService beepService)
    {
        _response = new APIResponse();
        
        _beepService = beepService;
    }
    
    [HttpPost]
    [Route("PostPayment")]
    public async Task<ActionResult<TransactionStatusDto>> PostPayment(PaymentPacketDto packet)
    {

        var authStatus = new AuthStatus();
        
        //Authentication Check
        if (packet.payload.credentials.username != "sandboxUser" || packet.payload.credentials.password!="sandboxPassword!")
        {
            authStatus.AuthStatusCode = 132;
            authStatus.AuthStatusDescription = SD.AuthStatusCode[132];

            _response.IsSuccess = false;
            _response.HttpStatusCode = HttpStatusCode.Unauthorized;
            _response.Result = authStatus;
            
            return BadRequest(_response);
        }
        else //login with code 131
        {
            authStatus.AuthStatusCode = 131;
            authStatus.AuthStatusDescription = SD.AuthStatusCode[131];
            
            _response.IsSuccess = true;
            _response.HttpStatusCode = HttpStatusCode.Accepted;
            
            //Generate transaction status and save it in db.

            
            //var transactionStatus = new TransactionStatus();
            var response = await _beepService.PostPayment<TransactionStatusDto>(packet);
            _response.Result = response;
            
            return Ok(_response);

        }
        
    }
    
    [HttpPost]
    [Route("QueryBill")]
    public async Task<ActionResult<QueryResponseDto>> QueryBill(QueryBillDto packet)
    {
        
        // var responseJson =
        //     "{\"GH-MTN-Plans\":[{\"bundleName\":\"24.05MB for GHc 0.5 \",\"value\":\"24.05 MB\",\"price\":\"GHc 0.5\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNDB1\\\"}\"},{\"bundleName\":\"48.10MB for GHc 1 \",\"value\":\"48.10 MB\",\"price\":\"GHc 1\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNDB2\\\"}\"},{\"bundleName\":\"471.70MB for GHc 3\",\"value\":\"471.70 MB\",\"price\":\"GHc 3\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNDB3\\\"}\"},{\"bundleName\":\"971.82MB for GHc 10\",\"value\":\"971.82 MB\",\"price\":\"GHc 10\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNDB4\\\"}\"},{\"bundleName\":\"241.09GB for GHc 399\",\"value\":\"241.09 GB\",\"price\":\"GHc 399\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNDB5\\\"}\"},{\"bundleName\":\"Kokrokoo 400MB + 20 Mins for GHc 1.09\",\"value\":\"400 MB & 20 Mins\",\"price\":\"GHc 1.09\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"KOKROKOO\\\"}\"},{\"bundleName\":\"96.15MB Social Media for GHc 1\",\"value\":\"96.15 MB\",\"price\":\"GHc 1\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNSMB1\\\"}\"},{\"bundleName\":\"480.77MB Social Media for GHc 5\",\"value\":\"480.77 MB\",\"price\":\"GHc 5\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNSMB2\\\"}\"},{\"bundleName\":\"961.54MB Social Media for GHc 10 \",\"value\":\"961.54 MB\",\"price\":\"GHc 10\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNSMB3\\\"}\"},{\"bundleName\":\"183.49MB Video for GHc 1\",\"value\":\"183.49 MB\",\"price\":\"GHc 1\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNVB1\\\"}\"},{\"bundleName\":\"917.43MB Video for GHc 5\",\"value\":\"917.43 MB\",\"price\":\"GHc 5\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNVB2\\\"}\"},{\"bundleName\":\"1.79GB Video for GHc 10\",\"value\":\"1.79 GB\",\"price\":\"GHc 10\",\"validity\":\"No Expiry\",\"extraData\":\"{\\\"productCode\\\":\\\"MTNVB3\\\"}\"}]}";
        // var plans = JsonConvert.DeserializeObject<Dictionary<string,List<MTN_Plans>>>(responseJson);
        // var plansDetails = plans.First().Value;
        
        
        var authStatus = new AuthStatus();
//Authentication Check
        if (packet.payload.credentials.username != "sandboxUser" || packet.payload.credentials.password!="sandboxPassword!")
        {
            authStatus.AuthStatusCode = 132;
            authStatus.AuthStatusDescription = SD.AuthStatusCode[132];

            _response.IsSuccess = false;
            _response.HttpStatusCode = HttpStatusCode.Unauthorized;
            _response.Result = authStatus;
            
            return BadRequest(_response);
        }
        else //login with code 131
        {
            authStatus.AuthStatusCode = 131;
            authStatus.AuthStatusDescription = SD.AuthStatusCode[131];
            
            _response.IsSuccess = true;
            _response.HttpStatusCode = HttpStatusCode.Accepted;
            
            //Generate transaction status and save it in db.

            var response = await _beepService.QueryBill<QueryResponseDto>(packet);
            _response.Result = response;
            
            return Ok(_response);

        }

    }
}

