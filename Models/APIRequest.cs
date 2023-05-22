﻿using BeepPayment.ConsumeAPI.Utility;

namespace BeepPayment.ConsumeAPI.Models;

public class APIRequest
{
    public SD.ApiType ApiType { get; set; } = SD.ApiType.GET;
    public string Url { get; set; }
    public object Data { get; set; }
}