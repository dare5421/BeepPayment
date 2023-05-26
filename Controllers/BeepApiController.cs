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
    private readonly ApplicationDbContext _db;
    private readonly IBeepPayoutService _beepService;

    public BeepApiController(ApplicationDbContext db, IBeepPayoutService beepService)
    {
        _response = new APIResponse();
        _db = db;
        _beepService = beepService;
    }
    
    [HttpPost]
    public async Task<ActionResult<TransactionStatusDto>> PostPayment(PaymentPacketDto packet)
    {

        // {
        //     HttpClient client = new HttpClient();
        //     HttpResponseMessage response =
        //         client.GetAsync("https://beep2.cellulant.africa:9001/paymentRouter/JSONV2/").Result;
        //     
        // }
        //
        //
        
        var authStatus = new AuthStatus();
        // var function = packet.BeepFunctionDto;
        // var credential = packet.CredentialDto;
        // var postPaymentPacket = packet.PostPaymentPacketDto;
        //Authentiacation Check
        if (packet.payload.credentials.username != "sandboxUser" || packet.payload.credentials.password!="sandboxPassword!")
        {
            authStatus.AuthStatusCode = 132;
            authStatus.AuthStatusDescription = SD.AuthStatusCode[132];

            _response.IsSuccess = false;
            //_response.ErrorMessages.Add("Username or password is incorecet!");
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

            
            var transactionStatus = new TransactionStatus();
            var response = await _beepService.PostPayment<TransactionStatusDto>(packet);
            _response.Result = response;
            
            return Ok(_response);

        }
        
        //Strange things happened code:174
        /*authStatus.AuthStatusCode = 174;
        authStatus.AuthStatusDescription = SD.AuthStatusCode[174];

        _response.IsSuccess = false;
        //_response.ErrorMessages.Add("Username or password is incorecet!");
        _response.HttpStatusCode = HttpStatusCode.Unauthorized;
        return BadRequest(_response);*/
        
    }
}