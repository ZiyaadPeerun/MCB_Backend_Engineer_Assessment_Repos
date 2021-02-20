using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares_API.Models
{
    public class UploadFile
    {
        public IFormFile files { get; set; }
    }
}
