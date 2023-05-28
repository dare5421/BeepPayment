using System.Net;
using BeepPayment.ConsumeAPI.Data;
using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Models.Dto;
using BeepPayment.ConsumeAPI.Services.IService;
using BeepPayment.ConsumeAPI.Utility;
using Microsoft.AspNetCore.Mvc;

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

