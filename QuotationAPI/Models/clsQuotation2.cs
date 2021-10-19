using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class clsQuotation2
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public clsDimension2 cartons { get; set; }
    }
    public class clsDimension2
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}