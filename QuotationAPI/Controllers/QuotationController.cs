using System.Web.Http;
using QuotationAPI.Models;
using System.Xml.Serialization;
using System.IO;

namespace QuotationAPI.Controllers
{
    public class QuotationController : ApiController
    {
        //API1
        [HttpPost]
        public double APIDimension1(clsQuotation1 objQuotation1)
        {
            //multiplier added as spCharges to differenciate the result
            double spCharges = 1.2;
            double total = spCharges * objQuotation1.dimensions.Height * objQuotation1.dimensions.Width * objQuotation1.dimensions.Length;
            return total;
        }

        [HttpPost]
        public double APIDimension2(clsQuotation2 objQuotation2)
        {
            //multiplier added as spCharges to differenciate the result
            double spCharges = 1.1;
            double amount = spCharges * objQuotation2.cartons.Height * objQuotation2.cartons.Width * objQuotation2.cartons.Length;
            return amount;
        }

        public double APIDimension3([FromBody] string xml)
        {
            //declaring xml root element
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "xml";
            // xRoot.Namespace = "http://www.cpandl.com";
            xRoot.IsNullable = true;

            var serializer = new XmlSerializer(typeof(clsQuotation3), xRoot);
            clsQuotation3 objQuotation3 = new clsQuotation3();

            //deserialization to object from xml
            using (TextReader reader = new StringReader(xml))
            {
                objQuotation3 = (clsQuotation3)serializer.Deserialize(reader);
            }
            //multiplier added as spCharges to differenciate the result
            double spCharges = 1.25;
            double quote = spCharges * objQuotation3.Packages.Height * objQuotation3.Packages.Width * objQuotation3.Packages.Length;
            return quote;
        }
    }
}
