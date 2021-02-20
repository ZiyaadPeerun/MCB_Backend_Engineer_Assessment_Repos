using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using McShares_API.Models;

namespace McShares_API.Interfaces
{
    public interface ISaveXMLData
    {
        public void save(UploadFile xmlDoc);
    }
}
