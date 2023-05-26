namespace BeepPayment.ConsumeAPI.Models.Dto;

public class PaymentPacketDto :BeepFunctionDto
{

    //public  BeepFunctionDto Function { get; set; }
    public Payload payload { get; set; }
    
}
public class Payload
{
    public  CredentialDto credentials { get; set; }
    public  PostPaymentPacketDto[] packet { get; set; }
}

