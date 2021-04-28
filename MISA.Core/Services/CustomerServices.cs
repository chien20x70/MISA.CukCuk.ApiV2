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

        protected override void CustomValidate(Customer entity, bool isCheckPutOrPost)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                // Check trùng mã: với isCheckPutOrPost là true thì là POST còn false thì là PUT
                var isPost = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode, customer.CustomerId, isCheckPutOrPost);
                var isPut = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode, customer.CustomerId, isCheckPutOrPost);
                if (isPost == true)
                {
                    throw new CustomerExceptions("Mã khách hàng đã tồn tại trên hệ thống!");
                }
                if (isPut == true)
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
