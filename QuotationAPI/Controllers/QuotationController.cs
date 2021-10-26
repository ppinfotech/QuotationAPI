using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuotationAPI.Controllers
{
    public class QuotationController : ApiController
    { 
        //API1
        [HttpPost]
        public async Task<Response> APIDimension1(InputDataModel requestModel)
        {
            try
            {
                //multiplier added as spCharges to differenciate the result                
                double spCharges = 1.2;
                double total = 0;
                for (int i = 0; i < requestModel.Dimensions.Length; i++)
                {
                    total +=
                        requestModel.Dimensions[i].Height *
                        requestModel.Dimensions[i].Length *
                        requestModel.Dimensions[i].Width *
                        spCharges;
                }
                var response = new Response();
                response.Amount = (decimal)total;
                response.ProviderName = "SP1";
                response.Success = true;
                return await Task.FromResult(response);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //API2
        [HttpPost]
        public async Task<Response> APIDimension2(InputDataModel requestModel)
        {
            try
            {
                //multiplier added as spCharges to differenciate the result                
                double spCharges = 1.5;
                double total = 0;
                for (int i = 0; i < requestModel.Dimensions.Length; i++)
                {
                    total +=
                        requestModel.Dimensions[i].Height *
                        requestModel.Dimensions[i].Length *
                        requestModel.Dimensions[i].Width *
                        spCharges;
                }
                var response = new Response();
                response.Amount = (decimal)total;
                response.ProviderName = "SP2";
                response.Success = true;
                return await Task.FromResult(response);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //API1
        [HttpPost]
        public async Task<Response> APIDimension3(InputDataModel requestModel)
        {
            try
            {
                //multiplier added as spCharges to differenciate the result                
                double spCharges = 1.8;
                double total = 0;
                for (int i = 0; i < requestModel.Dimensions.Length; i++)
                {
                    total +=
                        requestModel.Dimensions[i].Height *
                        requestModel.Dimensions[i].Length *
                        requestModel.Dimensions[i].Width *
                        spCharges;
                }
                var response = new Response();
                response.Amount = (decimal)total;
                response.ProviderName = "SP3";
                response.Success = true;
                return await Task.FromResult(response);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public double APIDimension3([FromBody] string xml)
        //{
        //    //declaring xml root element
        //    XmlRootAttribute xRoot = new XmlRootAttribute();
        //    xRoot.ElementName = "xml";        
        //    xRoot.IsNullable = true;

        //    var serializer = new XmlSerializer(typeof(clsQuotation3), xRoot);
        //    clsQuotation3 objQuotation3 = new clsQuotation3();

        //    //deserialization to object from xml
        //    using (TextReader reader = new StringReader(xml))
        //    {
        //        objQuotation3 = (clsQuotation3)serializer.Deserialize(reader);
        //    }
        //    //multiplier added as spCharges to differenciate the result
        //    double spCharges = 1.25;
        //    double quote = spCharges * objQuotation3.Packages.Height * objQuotation3.Packages.Width * objQuotation3.Packages.Length;
        //    return quote;
        //}
    }
}
