﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Interfaces;
using McShares_API.Models;

namespace McShares_API.Services
{

    public class QueryService : IQuery
    {
        private readonly DBContext _context;
        public QueryService(DBContext dBContext)
        {
            _context = dBContext;
        }

        public List<DataItem_Customer> getListRecords()
        {
            return _context.dataItem_Customer.ToList();
        }

        public ReturnQueryModel getByCustomerID(string customer_id)
        {
            var customer = _context.dataItem_Customer.Find(customer_id);
            ReturnQueryModel returnQueryModel = new ReturnQueryModel();
            if (customer != null)
            {
                returnQueryModel.customer_id = customer.customer_id;
                returnQueryModel.CustomerName = customer.Contact_Name;
                returnQueryModel.Customer_Type = customer.Customer_Type;
                if (customer.Customer_Type == ECustomerType.Individual.ToString())
                { returnQueryModel.Date_Of_Birth = customer.Date_Of_Birth; }
                else { returnQueryModel.Date_Incorp = customer.Date_Incorp; }
                returnQueryModel.Num_Shares = customer.Num_Shares;
                returnQueryModel.Share_Price = customer.Share_Price;
                returnQueryModel.Balance = customer.Share_Price * customer.Num_Shares;
            }
            else
            {
                return null;
            }
            return returnQueryModel;
        }

        public updateNumberOfSharesModel updateNumberOfShares(string customer_id, int numShares)
        {
            updateNumberOfSharesModel returnModel = new updateNumberOfSharesModel();

            var customer = _context.dataItem_Customer.Find(customer_id);
            if (customer != null)
            {
                if (customer.Customer_Type != ECustomerType.Corporate.ToString())
                {
                    customer.Num_Shares = numShares;
                    _context.SaveChanges();
                    returnModel.newBalance = customer.Num_Shares * customer.Share_Price;
                    returnModel.isSuccess = true;
                    return returnModel;
                }
                else
                {
                    //customer is a corporate
                    returnModel.isSuccess = false;
                    return returnModel;
                } 
            }
            returnModel.isSuccess = false;
            return returnModel;
        }

        public bool updateContactNumber(string customer_id, string contactNum)
        {
            var customer = _context.dataItem_Customer.Find(customer_id);
            if (customer != null)
            {
                customer.Contact_Number = contactNum;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteCustomer(string customer_id)
        {
            var customer = _context.dataItem_Customer.Find(customer_id);

            if (customer != null)
            {
                _context.dataItem_Customer.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<DataItem_Customer> searchByName(string searchTerm)
        {
            string[] parts = searchTerm.ToLower().Split();
            string p1 = parts.Length < 1 ? "" : parts[0];
            string p2 = parts.Length < 2 ? "" : parts[1];

            var result = _context.dataItem_Customer.Where(n =>
                (n.Contact_Name.ToLower().Contains(p1)) || ((n.Contact_Name.ToLower().Contains(p2))));
            return result;
        }
    }
}
