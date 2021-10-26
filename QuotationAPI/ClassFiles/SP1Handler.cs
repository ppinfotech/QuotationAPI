using Newtonsoft.Json.Linq;
using QuotationAPI.Interfaces;
using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuotationAPI.ClassFiles
{
    public class SP1Handler : HttpHandlerBase, ISPData
    {
        private readonly InputDataModel _requestModel;
        private string apiUrl = "http://localhost:59568/api/Quotation/APIDimension1";
        public SP1Handler(InputDataModel requestModel)
        {
            _requestModel = requestModel;
        }
        public override IApiDetails ShippingProviderApiDetails =>
            new ApiDetails(ResponseTypes.Json, apiUrl, new ApiAuthentication("consumerkey", "secertKey"));

        public override string GetApiAcceptedDataFormat()
        {            
            dynamic jsonObject = new JObject();
            jsonObject.contactAddress = JObject.FromObject(_requestModel?.ContactAddress);
            jsonObject.warehouseAddress = JObject.FromObject(_requestModel?.WarehouseAddress);
            jsonObject.cartonDeminsions = new JArray(_requestModel?.Dimensions);
            return jsonObject.ToString();
        }

        public async Task<Response> GetCost()
        {
            var amount = new Response { ProviderName = "SP1" };            
            await MakeRequest(response =>
            {                
                if (response != string.Empty)
                {
                    dynamic parsedJsonObject = ParseToJsonObject(response);
                    amount.Success = true;
                    amount.Amount = Convert.ToDecimal(parsedJsonObject.amount) ?? 0.0;
                }
            });
            return amount;
        }
    }
}