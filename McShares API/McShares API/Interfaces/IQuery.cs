﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Models;

namespace McShares_API.Interfaces
{
    public interface IQuery
    {
        public List<DataItem_Customer> getListRecords();
        public ReturnQueryModel getByCustomerID(string customer_id);
        public updateNumberOfSharesModel updateNumberOfShares(string customer_id, int numShares);
        public bool updateContactNumber(string customer_id, string contactNum);
        public bool deleteCustomer(string customer_id);
        public IQueryable<DataItem_Customer> searchByName(string searchTerm);
    }
}
