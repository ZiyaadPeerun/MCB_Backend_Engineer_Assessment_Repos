﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares_API.Models
{
    public class updateNumberOfSharesModel
    {
        public bool isSuccess { get; set; }
        public decimal newBalance { get; set; }
    }
}
