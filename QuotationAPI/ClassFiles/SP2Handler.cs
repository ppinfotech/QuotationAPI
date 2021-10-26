using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuotationAPI.Interfaces;
using QuotationAPI.Models;

namespace QuotationAPI.ClassFiles
{
    public class SP2Handler : HttpHandlerBase, ISPData
    {
        private readonly InputDataModel _requestModel;
        private string apiUrl = "http://localhost:59568/api/Quotation/APIDimension2";
        public SP2Handler(InputDataModel requestModel)
        {
            _requestModel = requestModel;
        }

        public override string GetApiAcceptedDataFormat()
        {
            //serilization 
            dynamic jsonObject = new
            {
                consignee = _requestModel?.ContactAddress,
                consignor = _requestModel?.WarehouseAddress,
                cartons = _requestModel?.Dimensions
            };
            return JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
        }
        public override IApiDetails ShippingProviderApiDetails =>
            new ApiDetails(ResponseTypes.Json, apiUrl, new ApiAuthentication("UserId", "SecreteKey"));
        public async Task<Response> GetCost()
        {
            var amount = new Response { ProviderName = "SP2" };
            await MakeRequest(response =>
            {
                if (response != string.Empty)
                {
                    dynamic parsedJsonObject = ParseToJsonObject(response);
                    amount.Success = true;
                    amount.Amount = Convert.ToDecimal(parsedJsonObject["total"]) ?? 0.0;
                }
            });
            return amount;
        }
    }
}