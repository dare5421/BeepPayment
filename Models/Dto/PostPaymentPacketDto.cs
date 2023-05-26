﻿namespace BeepPayment.ConsumeAPI.Models.Dto;

public class PostPaymentPacketDto //: CredentialDto
{
    
    //This is the product code used in identifying the service the customer is consuming e.g. TIGOAIRTIME
    public string serviceCode { get; set; }

    //The mobile number of the customer performing the payment. The MSISDN should begin with a country code e.g. 254xxxxxxxxx
    public string MSISDN { get; set; }

    //The reference ID generated by the receiver (merchant) client system for the transaction.
    public string? invoiceNumber { get; set; }

    //Account number is the recipient of payment . If it’s a mobile number it should begin with a country code e.g. 254xxxxxxxxx
    public string accountNumber { get; set; }

    //The unique transactionID generated by the bank for this transaction.
    public string payerTransactionID { get; set; }

    //The amount paid by the customer.
    public double amount { get; set; }

    //A narration of the payment being made.
    public string? narration { get; set; }

    //The date the payer received payment. yyyy-mm-dd hh:mm:ss.
    public string datePaymentReceived { get; set; }

    //The ISO code for the transaction currency.
    public string currencyCode { get; set; }

    //Unique hub transaction ID
    public string? hubID { get; set; }

    //The payment mode used for example ATM, Mobile, etc
    public string? paymentMode { get; set; }

    //The name of the customer as given on the payer’s end
    public string? customerNames { get; set; }

    //Any extra parameter or information you need to pass in a key-value JSON format i.e. callBackUrl
    public ExtraData extraData { get; set; }
}

public class ExtraData
{
    public string callBackUrl { get; set; }
}