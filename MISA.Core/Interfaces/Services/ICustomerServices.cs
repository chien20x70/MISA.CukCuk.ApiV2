
using MISA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerServices
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(Guid customerId);
        public int InsertCustomer(Customer customer);
        public int UpdateCustomer(Guid customerId, Customer customer);
        public int DeleteCustomer(Guid customerId);

    }
}
