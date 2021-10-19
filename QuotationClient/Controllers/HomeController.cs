using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QuotationClient.Models;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Xml;


namespace QuotationClient.Controllers
{
    public class HomeController : Controller
    {
        //API Main Path defined
        string apiUrl = "http://localhost:59568/api/Quotation";
        public ActionResult Index()
        {
            //passing null object
            clsQuotationVM obj = new clsQuotationVM();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(clsQuotationVM objQuotationVM)
        {
            try
            {
                //for first api call
                var input1 = new
                {
                    ContactAddress = objQuotationVM.SourceAddress,
                    WarehouseAddress = objQuotationVM.DestinationAddress,
                    dimensions = new
                    {
                        Height = objQuotationVM.listDimension.Height,
                        Width = objQuotationVM.listDimension.Width,
                        Length = objQuotationVM.listDimension.Length
                    }

                };
                //serialized json
                string inputJson1 = (new JavaScriptSerializer()).Serialize(input1);
                WebClient client1 = new WebClient();
                client1.Headers["Content-type"] = "application/json";
                client1.Encoding = Encoding.UTF8;
                string json1 = client1.UploadString(apiUrl + "/APIDimension1", inputJson1);

                //first result will be stored in output1
                double output1 = Convert.ToDouble(json1);
                //output1 data will be stored in clsOutput object that is used later
                clsOutput objOutput1 = new clsOutput();
                objOutput1.Provider = "SP1";
                objOutput1.total = output1;


                //api2 call process start
                var input2 = new
                {
                    Consignee = objQuotationVM.SourceAddress,
                    Consignor = objQuotationVM.DestinationAddress,
                    cartons = new
                    {
                        Height = objQuotationVM.listDimension.Height,
                        Width = objQuotationVM.listDimension.Width,
                        Length = objQuotationVM.listDimension.Length
                    }

                };
                //serialized json
                string inputJson2 = (new JavaScriptSerializer()).Serialize(input2);
                WebClient client2 = new WebClient();
                client2.Headers["Content-type"] = "application/json";
                client2.Encoding = Encoding.UTF8;
                string json2 = client2.UploadString(apiUrl + "/APIDimension2", inputJson2);

                //output of api2 will be stored in output2
                double output2 = Convert.ToDouble(json2);
                //result stored in object, used later
                clsOutput objOutput2 = new clsOutput();
                objOutput2.Provider = "SP2";
                objOutput2.total = output2;

                //api3 process started
                var input3 = new
                {
                    xml = new
                    {
                        Source = objQuotationVM.SourceAddress,
                        Destination = objQuotationVM.DestinationAddress,
                        Packages = new
                        {
                            Height = objQuotationVM.listDimension.Height,
                            Width = objQuotationVM.listDimension.Width,
                            Length = objQuotationVM.listDimension.Length
                        }
                    }
                };

                //serialized json
                var inputJson3 = (new JavaScriptSerializer()).Serialize(input3);
                // To convert JSON text contained in string json into an XML node
                XmlDocument doc = JsonConvert.DeserializeXmlNode(inputJson3);
                double output3 = 0;
                using (var client3 = new WebClient())
                {
                    client3.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string json3 = client3.UploadString(apiUrl + "/APIDimension3", "POST", "=" + doc.InnerXml);
                    output3 = Convert.ToDouble(json3);
                }
                //result will be stored in output3 and then clsOutput object to use later
                clsOutput objOutput3 = new clsOutput();
                objOutput3.Provider = "SP3";
                objOutput3.total = output3;

                //object created to return in view parameter
                clsQuotationVM objOutput = new clsQuotationVM();
                List<clsOutput> outputList = new List<clsOutput>();
                //all 3 obejects added to list
                outputList.Add(objOutput1);
                outputList.Add(objOutput2);
                outputList.Add(objOutput3);
                objOutput.output = outputList.OrderBy(p => p.total).ToList();
                ViewBag.Msg = "API Call Success";
                return View(objOutput);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View();
            }
        }
    }
}