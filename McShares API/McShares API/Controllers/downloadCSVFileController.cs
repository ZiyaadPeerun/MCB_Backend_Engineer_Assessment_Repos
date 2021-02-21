using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Interfaces;

namespace McShares_API.Controllers
{
    //private readonly IDownloadCSVFile _downloadCSVFile;
    public class downloadCSVFileController : Controller
    {
       public downloadCSVFileController(IDownloadCSVFile downloadCSVFile)
        {
           // _downloadCSVFile = downloadCSVFile;
        }
        //[Authorize] uncomment for authentication

    }
}
