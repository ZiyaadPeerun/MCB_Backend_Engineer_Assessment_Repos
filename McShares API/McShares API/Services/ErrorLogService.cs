using McShares_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McShares_API.Interfaces;

namespace McShares_API.Services
{
    public class ErrorLogService: ILogError
    {
        private readonly DBContext _context;
        public ErrorLogService(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void logError(DateTime dt, string description)
        {
            try
            {
                LogErrors log = new LogErrors();
                log.errorTime = dt;
                log.description = description;
                _context.logErrors.Add(log);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }  
    }
}
