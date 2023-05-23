namespace BeepPayment.ConsumeAPI.Models.Dto;

public class PaymentPacketDto :BeepFunctionDto
{

    //public  BeepFunctionDto Function { get; set; }
    public Payload Payload { get; set; }
    
}
public class Payload
{
    public  CredentialDto Credentials { get; set; }
    public  PostPaymentPacketDto[] Packet { get; set; }
}

