using McShares_API.Interfaces;
using McShares_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares_API.Controllers
{
    public class saveXMLDataController : Controller
    {
        //private readonly IHostingEnvironment _env;
        //private readonly IValidateXMLFile _IValidateXMLFile;
        private readonly ISaveXMLData _ISaveXMLData;

        public saveXMLDataController(ISaveXMLData iSaveXMLData)
        {
            //_env = environment;
            //_IValidateXMLFile = iValidateXMLFile;
            _ISaveXMLData = iSaveXMLData;
        }

        [HttpPost]
        [Route("uploadAndSave")]
        public IActionResult uploadAndSave([FromForm] UploadFile obj)
        {
            try
            {
                _ISaveXMLData.save(obj);
                return Ok("XML data successfully saved to sql server");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
           

           
            
            //return _IValidateXMLFile.ValidateXmlFile(obj) ? Ok("XML document validation failed!") : Ok("XML document has been validated successfully!");
        }
    }
}
