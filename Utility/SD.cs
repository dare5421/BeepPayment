namespace BeepPayment.ConsumeAPI.Utility;

public static class SD
{
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    
    public static Dictionary<int,string> TransactionStatusCode = new ()
    {
        {104,"Generic exception occurred with matching appropriate description"},
        {106,"Inactive service"},
        {109,"Customer MSISDN missing"},
        {110,"Invalid Customer MSISDN"},
        {111,"Invalid invoice amount"},
        {115,"Invalid currency code specified"},
        {120,"Account number not specified"},
        {139,"Payment posted successfully and pending acknowledgement."},
        {146,"Invoice does not exist"},
        {167,"Invalid serviceID"},
        {174,"Generic failure occurred with appropriate status description"},
        {229,"Duplicate payment found"},
        {230,"Insufficient Float Balance"},
        {231,"Amount specified is greater than maximum allowed for service"},
        {232,"Amount specified is less than minimum allowed for service"}
    };

    public static Dictionary<int, string> AuthStatusCode = new()
    {
        {131,"Client authenticated successfully"},
        {132,"Client authentication failed"},
        {174,"Generic failure status code with matching appropriate description"}
    };

}
