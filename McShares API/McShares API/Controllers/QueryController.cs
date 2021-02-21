﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Interfaces;
using McShares_API.Models;
using Microsoft.AspNetCore.Http;

namespace McShares_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQuery _Iquery;
        public QueryController(IQuery _iquery)
        {
            _Iquery = _iquery;
        }

        [HttpGet]
        [Route("getAllRecords")]
        public ActionResult<IEnumerable<string>> getAllRecords()
        {
            try
            {
                var list= _Iquery.getListRecords();
                if (list.Any()){ return Ok(list); }
                else{ return NotFound("No data"); }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
        }

        [HttpGet("{customer_id}")]
        public ActionResult<ReturnQueryModel> getByCustomerID(string customer_id)
        {
            try
            {
                var customer = _Iquery.getByCustomerID(customer_id);
                if (customer!= null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound("Wrong Customer ID: Please try again.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }       
        }

        [HttpGet]
        [Route("SearchByName")]
        public ActionResult<IQueryable<DataItem_Customer>> SearchByName(string searchTerm)
        {
            try
            {
                var customer = _Iquery.searchByName(searchTerm);
                if (customer!=null) { return Ok(customer.ToList()); }
                else { return NotFound("No Result."); }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
        }

        [HttpPut]
        [Route("updateNumberShares")]
        public ActionResult Put(string custId, [FromBody] int numShares)
        {
            try
            {
              var returnModel = _Iquery.updateNumberOfShares(custId, numShares);
              if (returnModel.isSuccess) { return Ok("Number of shares for customer " + custId + " updated successfully!"+ "\nUpdated balance: $"+returnModel.newBalance); }
              else{ return NotFound("Update failed!");}
            } catch (Exception e ){return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");}   
        }

        [HttpPut]
        [Route("updateContactNumber")]
        public ActionResult Put(string custId, string contactNumber)
        {
            try
            {
                var isSuccess = _Iquery.updateContactNumber(custId, contactNumber);
                if (isSuccess) { return Ok("Contact number for customer " + custId + " updated successfully!" + "\nUpdated Number: " + contactNumber); }
                else { return NotFound("Update failed!"); }
            }
            catch (Exception e) { return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}"); }
        }

        [HttpDelete("{custId}")]
        public ActionResult Delete(string custId)
        {
            try
            {
                var isSuccess = _Iquery.deleteCustomer(custId);
                if (isSuccess) { return Ok("Customer " + custId + " deleted successfully!"); }
                else { return NotFound("Update failed!"); }
            }
            catch (Exception e) { return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}"); }
        }
    }
}