using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class clsQuotation3
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public clsDimension3 Packages { get; set; }
    }
    public class clsDimension3
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}