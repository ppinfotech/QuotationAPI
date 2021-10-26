using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Interfaces
{
    public interface IInputData
    {
        Address ContactAddress { get; set; }
        Address WarehouseAddress { get; set; }
        Dimension[] Dimensions { get; set; }
    }
}