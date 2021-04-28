using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired: Attribute
    {
        public string MsgError;
        public MISARequired(string msgError)
        {
            MsgError = msgError;
        }
    }
}
