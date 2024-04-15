using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Core.Exceptions
{
    public class WineDeletionException :Exception
    {
        public WineDeletionException()
        {
        }

        public WineDeletionException(string message)
            : base(message)
        {
        }

        public WineDeletionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
