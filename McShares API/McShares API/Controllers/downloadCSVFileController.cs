using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;
using McShares_API.Models;

namespace McShares_API.Controllers
{
    
    public class downloadCSVFileController : Controller
    {
        private readonly DBContext _context;
        public downloadCSVFileController(DBContext dBContext)
        {
            _context = dBContext;
        }

        [HttpPost]
        //[Authorize] uncomment for authentication
        [Route("DownloadCSVFile")]
        public IActionResult DownloadCSVFile()
        {
            try
            {
                var customers=_context.dataItem_Customer.ToList();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("CustomerID,CustomerName,CustomerType,NumberOfShares,SharePrice");

                foreach(var cust in customers)
                {
                    sb.AppendLine($"{cust.customer_id},{cust.Contact_Name},{cust.Customer_Type},{cust.Num_Shares},{cust.Share_Price}");
                }
                return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "McShares.csv");
            }
            catch (Exception e) { return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}"); }
        }
    }
}
