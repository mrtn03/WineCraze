using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Core.Exceptions
{
    public class WineUpdateException : Exception
    {
        public WineUpdateException() { }

        public WineUpdateException(string message) : base(message) { }

        public WineUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}