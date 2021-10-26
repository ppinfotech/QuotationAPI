using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Interfaces
{
    public interface IApiDetails
    {
        ResponseTypes ResponseType { get; }
        string ApiBaseUrl { get; }
        ApiAuthentication ApiCredentials { get; }
    }
}