using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string ProviderName { get; set; }
        public decimal Amount { get; set; }
    }
}