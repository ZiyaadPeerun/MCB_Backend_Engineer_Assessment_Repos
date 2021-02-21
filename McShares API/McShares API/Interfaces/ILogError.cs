using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares_API.Interfaces
{
    public interface ILogError
    {
        public void logError(DateTime dt, string description);
    }
}
