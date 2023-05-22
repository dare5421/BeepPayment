using System.Net;
using BeepPayment.ConsumeAPI.Data;
using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeepPayment.ConsumeAPI.Controllers;

[ApiController]
[Route("api/BeepAPI")]
public class BeepApiController : ControllerBase
{

    private APIResponse _response;
    // private readonly IRepository<APIResponse> _dbBeep;
    private readonly ApplicationDbContext _db;

    public BeepApiController(ApplicationDbContext db)
    {
        _response = new APIResponse();
        _db = db;
    }
    
    [HttpPost]
    public async Task<ActionResult<APIResponse>> PostPayment(PostPaymentPacketDto packet)
    {



        _response.HttpStatusCode = HttpStatusCode.Accepted;
        return _response;
    }
}