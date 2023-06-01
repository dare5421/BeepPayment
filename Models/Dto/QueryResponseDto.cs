namespace BeepPayment.ConsumeAPI.Models.Dto;

public class QueryResponseDto
{
    public AuthStatus authStatus { get; set; }
    public List<QueryResponseStatus> results { get; set; }
}