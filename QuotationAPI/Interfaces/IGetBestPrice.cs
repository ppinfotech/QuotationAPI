using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuotationAPI.Interfaces
{
    public interface IGetBestPrice
    {
        Task<Response> GetQuotation(InputDataModel inputDataModel);
    }
}