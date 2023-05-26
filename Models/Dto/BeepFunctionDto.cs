namespace BeepPayment.ConsumeAPI.Models.Dto;

public class BeepFunctionDto
{
    //Country ISO code letter i.e. KE,GH,TZ
    public string countryCode { get; set; }
    //Function being invoked
    public string function { get; set; }
}