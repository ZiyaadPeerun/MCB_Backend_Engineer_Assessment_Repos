using McShares_API.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using McShares_API.Interfaces;
using System.Xml;

namespace McShares_API.Services
{
    public class ValidateXMLFileService: IValidateXMLFile
    {
        private readonly IHostingEnvironment _env;
        private readonly ISaveXMLData _saveXMLData;

        public ValidateXMLFileService(IHostingEnvironment environment, ISaveXMLData saveXMLData)
        {
            _env = environment;
            _saveXMLData = saveXMLData;
        }

        public bool ValidateXmlFile(UploadFile obj)
        {
            //Loads the xml file
            XDocument xmlDoc = XDocument.Load(obj.files.OpenReadStream());

            //Retrieve the base path of the solution
            var basePath = _env.ContentRootPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", basePath + "\\McShares_2018.xsd");

            Console.WriteLine("Validating Xml document");
            bool errors = false;
            xmlDoc.Validate(schema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            
            //Age check
            for (int i = 0; i < xmlDoc.ToXmlDocument().GetElementsByTagName("DataItem_Customer").Count; i++)
            {
                if (xmlDoc.ToXmlDocument().GetElementsByTagName("DataItem_Customer")[i].ChildNodes[2].InnerXml != "")
                {
                   var dob = Convert.ToDateTime(xmlDoc.ToXmlDocument().GetElementsByTagName("DataItem_Customer")[i].ChildNodes[2].InnerXml);
                   var now = DateTime.Now;
                   var age = now - dob;
                    if (age.TotalDays < 6575)
                    {
                        return true;
                    }
                }    
            }
            Console.WriteLine("The Xml document {0}", errors ? "did not validate" : "validated");
            var returnStatus = errors;
            return returnStatus;
        }
    }


    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }
    }
}

