using QuotationAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class InputDataModel : IInputData
    {
        public InputDataModel()
        {
            ContactAddress = new Address();
            WarehouseAddress = new Address();
            Dimensions = new Dimension[] { };
        }
        [Required]
        public Address ContactAddress { get; set; }
        [Required]
        public Address WarehouseAddress { get; set; }

        public Dimension[] Dimensions { get; set; }
    }
}