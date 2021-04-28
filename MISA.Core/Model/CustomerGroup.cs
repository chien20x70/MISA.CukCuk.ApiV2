using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.CustomAttribute;

namespace MISA.Core.Model
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }

        [MISARequired("")]
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
