namespace BeepPayment.ConsumeAPI.Models.Dto;

public class Payload
{
    public  CredentialDto credentials { get; set; }
    public  PostPaymentPacketDto[] packet { get; set; }
}