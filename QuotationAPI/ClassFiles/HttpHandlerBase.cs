using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using QuotationAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuotationAPI.Models;

namespace QuotationAPI.ClassFiles
{
    public abstract class HttpHandlerBase
    {
        private readonly HttpClient _httpClient;

        protected HttpHandlerBase()
        {
            _httpClient = new HttpClient();
        }

        public HttpClient HttpClient => _httpClient;
        public abstract IApiDetails ShippingProviderApiDetails { get; }

        protected void AddRequestHeader(string headerName, string headerValue)
        {
            HttpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }

        private string MediaType =>
            ShippingProviderApiDetails != null && ShippingProviderApiDetails.ResponseType == ResponseTypes.Json
                ? "application/json"
                : "application/xml";

        protected JObject ParseToJsonObject(string json)
        {
            return JObject.Parse(json);
        }

        protected string ParseToXml<TObject>(TObject obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TObject));
            var stringWriter = new StringWriter();
            XmlWriter writer = XmlWriter.Create(stringWriter);
            xmlSerializer.Serialize(writer, obj);
            return stringWriter.ToString();
        }

        public abstract string GetApiAcceptedDataFormat();


        protected async Task MakeRequest(Action<string> onSuccess)
        {
            try
            {
                if (ShippingProviderApiDetails == null)
                {
                    throw new ArgumentNullException(nameof(ShippingProviderApiDetails));
                }
                if (string.IsNullOrEmpty(ShippingProviderApiDetails.ApiBaseUrl))
                {
                    throw new Exception("Not Found");
                }

                var data = GetApiAcceptedDataFormat();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(MediaType));

                var stringContent = new StringContent(data, Encoding.UTF8, MediaType);

                var response = await _httpClient.PostAsync(new Uri(ShippingProviderApiDetails.ApiBaseUrl), stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    onSuccess?.Invoke(responseContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}