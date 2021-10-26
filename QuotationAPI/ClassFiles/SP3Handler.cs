using QuotationAPI.Interfaces;
using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace QuotationAPI.ClassFiles
{
    public class SP3Handler
    {

        public SP3Handler()
        {

        }
        public SP3Handler(InputDataModel shippingRequestModel)
        {
            if (shippingRequestModel == null) throw new ArgumentNullException(nameof(shippingRequestModel));
            Source = shippingRequestModel.ContactAddress;
            Destination = shippingRequestModel.WarehouseAddress;
            dimension = shippingRequestModel.Dimensions;
        }
        public Address Source { get; set; }
        public Address Destination { get; set; }
        public Dimension[] dimension { get; set; }
    }


    public class SP3Provider : HttpHandlerBase, ISPData
    {
        private string apiUrl = "http://localhost:59568/api/Quotation/APIDimension3";
        private readonly InputDataModel _requestModel;
        public SP3Provider(InputDataModel requestModel)
        {
            _requestModel = requestModel;

        }
        public override IApiDetails ShippingProviderApiDetails =>
            new ApiDetails(ResponseTypes.Xml, apiUrl, new ApiAuthentication("UserId", "SecreteKey"));


        public override string GetApiAcceptedDataFormat()
        {
            SP3Handler xmlObject = new SP3Handler(_requestModel);
            return ParseToXml(xmlObject);
        }

        public async Task<Response> GetCost()
        {
            var amount = new Response { ProviderName = "SP3" };            
            await MakeRequest(xmlResponse =>
            {
                if (xmlResponse != string.Empty)
                {
                    var doc = XDocument.Parse(xmlResponse);
                    amount.Amount = Convert.ToDecimal(((XElement)(doc.FirstNode)).Value);
                    amount.Success = true;
                }
            });
            return amount;
        }
    }
}