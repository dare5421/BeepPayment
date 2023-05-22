namespace BeepPayment.ConsumeAPI.Models.Dto;

public class BeepFunctionDto
{
    //Country ISO code letter i.e. KE,GH,TZ
    public string CountryCode { get; set; }
    //Function being invoked
    public string Function { get; set; }
}