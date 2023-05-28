using System.Reflection.Metadata.Ecma335;
using BeepPayment.ConsumeAPI.Models.Dto;
using Newtonsoft.Json;

namespace BeepPayment.ConsumeAPI.Models;

public class QueryResponseStatus
{
    public string AccountNumber { get; set; }
    public int ServiceId { get; set; }
    public string ServiceCode { get; set; }
    public string dueDate { get; set; }
    public string dueAmount { get; set; }
    public string currency { get; set; }
    public string customerName { get; set; }
    public ExtraDataBundle responseExtraData { get; set; }
    public string statusCode { get; set; }
    public string statusDescription { get; set; }
}

public class ExtraDataBundle
{
    [JsonProperty(PropertyName="GH-MTN-Plans")]
    public MTN_Plans[] Plans { get; set; }
}

public class MTN_Plans
{
    public string BundleName { get; set; }
    public string Value { get; set; }
    public string Price { get; set; }
    public string Validity { get; set; }
    public ExtraDataPlan ExtraData { get; set; }
}

public class ExtraDataPlan
{
    public string ProductCode { get; set; }
}