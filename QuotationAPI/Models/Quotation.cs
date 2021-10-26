using System.Web.Http;
using QuotationAPI.Models;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using QuotationAPI.Interfaces;
using System;
using System.Linq;
using QuotationAPI.ClassFiles;

namespace QuotationAPI.Controllers
{
    public class Quotation : IGetBestPrice
    {
        public static Response GetMinAmount(Response[] shippingCosts)
        {
            if (shippingCosts == null || shippingCosts.Length == 0) return null;            
            var amount = shippingCosts.OrderBy(x => x.Amount).FirstOrDefault();//will retrunt least amount
            return amount;
        }

        public async Task<Response> GetQuotation(InputDataModel inputDataModel)
        {
            try
            {
                if (inputDataModel == null) throw new ArgumentNullException(nameof(inputDataModel));                
                ISPData[] shippingProviders =
                {
                    //json
                    new SP1Handler(inputDataModel),
                    //json
                    new SP2Handler(inputDataModel),
                    //xml
                    new SP3Provider(inputDataModel),
                };
                var requests = shippingProviders.Select(x => x.GetCost());
                var response = await Task.WhenAll(requests);
                return GetMinAmount(response?.Where(x => x.Success).ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
