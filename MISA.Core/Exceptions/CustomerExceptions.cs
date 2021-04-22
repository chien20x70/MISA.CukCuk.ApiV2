using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    public class CustomerExceptions : Exception
    {
        public CustomerExceptions(string msg): base(msg)
        {

        }
    }
}
