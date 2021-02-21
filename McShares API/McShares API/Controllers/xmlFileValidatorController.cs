using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using McShares_API.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using McShares_API.Interfaces;

namespace McShares_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class xmlFileValidatorController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly IValidateXMLFile _IValidateXMLFile;

        public xmlFileValidatorController(IHostingEnvironment environment, IValidateXMLFile iValidateXMLFile) 
        {
            _env = environment;
            _IValidateXMLFile = iValidateXMLFile;
        }

        [HttpPost]
        [Route("ValidateXmlFile")]
        public IActionResult ValidateXmlFile([FromForm] UploadFile obj)
        {  
            return _IValidateXMLFile.ValidateXmlFile(obj)? Ok("XML document validation failed!") :Ok("XML document has been validated successfully!");
        }
    }
}
