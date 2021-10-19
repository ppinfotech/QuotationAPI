using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuotationClient.Models
{
    public class clsQuotationVM
    {
        [Required]
        [DisplayName("Source Address")]
        public string SourceAddress { get; set; }

        [Required]
        [DisplayName("Destination Address")]
        public string DestinationAddress { get; set; }

        [Required]
        public clsDimension listDimension { get; set; }

        public List<clsOutput> output { get; set; }
    }

    public class clsDimension
    {
        [Required]
        [DisplayName("Height")]
        public double Height { get; set; }

        [Required]
        [DisplayName("Width")]
        public double Width { get; set; }

        [Required]
        [DisplayName("Length")]
        public double Length { get; set; }
    }

    //for result display
    public class clsOutput
    {
        public double total { get; set; }
        public string Provider { get; set; }
    }    
}