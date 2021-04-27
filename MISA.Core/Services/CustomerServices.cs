using MISA.Core.Interfaces.Services;
using MISA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MISA.Core.Interfaces.Repository;
using MISA.Core.Exceptions;

namespace MISA.Core.Services
{
    public class CustomerServices : BaseServices<Customer>, ICustomerServices
    {
        // Khởi tạo kết nối interfaces
        ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository): base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override void Validate(Customer entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;

                // Validate dữ liệu:
                // - Check các thông tin bắt buộc nhập:
                CustomerExceptions.CheckCustomerCodeEmpty(customer.CustomerCode);

                // Check trùng mã:
                var isExits = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExits == true)
                {
                    throw new CustomerExceptions("Mã khách hàng đã tồn tại trên hệ thống!");
                }
                var phone = _customerRepository.CheckPhoneNumberExits(customer.PhoneNumber);
                if (phone)
                {
                    throw new CustomerExceptions("Số điện thoại đã tồn tại trên hệ thống!");
                }
                
            }
            
        }
    }
}
