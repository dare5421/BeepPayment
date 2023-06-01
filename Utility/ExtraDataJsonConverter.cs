using BeepPayment.ConsumeAPI.Models;
using BeepPayment.ConsumeAPI.Models.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace BeepPayment.ConsumeAPI.Utility;

public class ExtraDataJsonConverter : JsonConverter<QueryResponseDto>
{
    public override void WriteJson(JsonWriter writer, QueryResponseDto? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override QueryResponseDto? ReadJson(JsonReader reader, Type objectType, QueryResponseDto? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        QueryResponseDto queryResponseDto = new();
        List<QueryResponseStatus> queryResponseStatus = new(); //results
        ExtraDataBundle extraDataBundle = new(); //responseExtraData
        List<MTN_Plans> mtnPlansList = new(); //plans
        // ExtraDataPlan extraDataPlan = new();

        JObject jo = JObject.Load(reader);

        var serAuthStatus = JsonConvert.SerializeObject(jo["authStatus"]);
        var desAuthStatus = JsonConvert.DeserializeObject<AuthStatus>(serAuthStatus);
        queryResponseDto.authStatus = desAuthStatus;


        var result = jo["results"].First();
        var responseExtraData = result["responseExtraData"];
        var serailizedExtraData = JsonConvert.SerializeObject(responseExtraData);
        var serailizedExtraData2 = JsonConvert.DeserializeObject<string>(serailizedExtraData);
        var plansDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<JObject>>>(serailizedExtraData2);

        var plans = plansDictionary.First().Value;
        MTN_Plans plan = new MTN_Plans();
        foreach (var mtnPlans in plans)
        {
            var exData = JsonConvert.SerializeObject(mtnPlans["extraData"]);
            var desExDataStr = JsonConvert.DeserializeObject<string>(exData);
            var desExData = JsonConvert.DeserializeObject<ExtraDataPlan>(desExDataStr);

            plan.Value = mtnPlans["value"].ToString();
            plan.Price = mtnPlans["price"].ToString();
            plan.Validity = mtnPlans["validity"].ToString();
            plan.BundleName = mtnPlans["bundleName"].ToString();
            plan.ExtraData = desExData;
            mtnPlansList.Add(plan);
        }

        extraDataBundle.Plans = mtnPlansList;
        QueryResponseStatus query = new();
        query.responseExtraData = extraDataBundle;
        query.currency = result["currency"].ToString();
        query.customerName = result["customerName"].ToString();
        query.dueAmount = result["dueAmount"].ToString();
        query.dueDate = result["dueDate"].ToString();
        query.statusCode = result["statusCode"].ToString();
        query.statusDescription = result["statusDescription"].ToString();
        query.AccountNumber = result["accountNumber"].ToString();
        query.ServiceCode = result["serviceCode"].ToString();
        query.ServiceId = (int)result["serviceID"];

        queryResponseStatus.Add(query);

        queryResponseDto.results = queryResponseStatus;
        return queryResponseDto;
    }
}