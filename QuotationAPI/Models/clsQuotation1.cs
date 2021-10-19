using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class clsQuotation1
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress { get; set; }
        public clsDimension1 dimensions = new clsDimension1();
    }
    public class clsDimension1
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}