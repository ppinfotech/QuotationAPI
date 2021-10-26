using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class ApiAuthentication
    {
        public ApiAuthentication(string key, string secert)
        {
            Key = key;
            Secert = secert;
        }

        public string Key { get; set; }
        public string Secert { get; set; }
    }
}