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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace McShares_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class xmlFileValidatorController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly IValidateXMLFile _IValidateXMLFile;
        //private readonly ISaveXMLData _ISaveXMLData;

        public xmlFileValidatorController(IHostingEnvironment environment, IValidateXMLFile iValidateXMLFile) 
        {
            _env = environment;
            _IValidateXMLFile = iValidateXMLFile;
           // _ISaveXMLData = iSaveXMLData;
        }

        [HttpPost]
        [Route("ValidateXmlFile")]
        public IActionResult ValidateXmlFile([FromForm] UploadFile obj)
        {  
            return _IValidateXMLFile.ValidateXmlFile(obj)? Ok("XML document validation failed!") :Ok("XML document has been validated successfully!");
        }

        //[HttpPost]
        //[Route("uploadAndSave")]
        //public IActionResult uploadAndSave([FromForm] UploadFile obj)
        //{
        //    _ISaveXMLData.save(obj);


        //    return Ok();
        //    //return _IValidateXMLFile.ValidateXmlFile(obj) ? Ok("XML document validation failed!") : Ok("XML document has been validated successfully!");
        //}





        // GET: api/<xmlFileValidatorController>
        [HttpGet]
        public IActionResult Get()
        {
            //var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            //XmlSchemaSet schema = new XmlSchemaSet();
            //schema.Add("", path + "\\McShares_2018.xsd");
            //XmlReader rd = XmlReader.Create(path + "\\McShares_2018.xml");
            //XDocument doc = XDocument.Load(rd);

            //doc.Validate(schema, ValidationEventHandler);


            return Ok();
           



            
        }

       

        // GET api/<xmlFileValidatorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<xmlFileValidatorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {



        }

        // PUT api/<xmlFileValidatorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<xmlFileValidatorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
