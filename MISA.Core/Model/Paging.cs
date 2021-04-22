using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Model
{
    public class Paging<T>
    {
        public int totalRecord { get; set; }
        public int totalPages { get; set; }
        public IEnumerable<T> data { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
