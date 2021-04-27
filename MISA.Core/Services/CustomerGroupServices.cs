using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerGroupServices : BaseServices<CustomerGroup>, ICustomerGroupServices
    {
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupServices(ICustomerGroupRepository customerGroupRepository): base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
