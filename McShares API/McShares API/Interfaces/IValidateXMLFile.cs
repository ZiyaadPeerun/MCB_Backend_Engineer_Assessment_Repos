﻿using McShares_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares_API.Interfaces
{
    public interface IValidateXMLFile
    {
        public bool ValidateXmlFile(UploadFile obj);
    }
}
