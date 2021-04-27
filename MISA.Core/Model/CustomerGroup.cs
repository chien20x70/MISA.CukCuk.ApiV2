using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Model
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }

        [Required(ErrorMessage = "CustomerGroupName khong the de trong!")]
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
