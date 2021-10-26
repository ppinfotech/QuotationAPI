using QuotationAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class ApiDetails : IApiDetails
    {
        public ApiDetails(ResponseTypes responseType, string apiBaseUrl, ApiAuthentication apiCredentials)
        {
            ResponseType = responseType;
            ApiBaseUrl = apiBaseUrl;
            ApiCredentials = apiCredentials;
        }

        public ResponseTypes ResponseType { get; }
        public string ApiBaseUrl { get; }
        public ApiAuthentication ApiCredentials { get; }
    }
}