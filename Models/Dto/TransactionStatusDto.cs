namespace BeepPayment.ConsumeAPI.Models.Dto;

public class TransactionStatusDto
{
    public AuthStatus authStatus { get; set; }
    public TransactionStatus[] results { get; set; }
}