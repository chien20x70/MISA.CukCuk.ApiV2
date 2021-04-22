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
    public class CustomerServices : ICustomerServices
    {
        // Khởi tạo kết nối interfaces
        ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>rowAffects: Số dòng bị ảnh hướng khi xóa</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public int DeleteCustomer(Guid customerId)
        {
            var rowAffects = _customerRepository.DeleteCustomer(customerId);
            return rowAffects;
        }

        /// <summary>
        /// Lấy tất cả khách hàng trong DB
        /// </summary>
        /// <returns>customers: Danh sách khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        /// <summary>
        /// Lấy khách hàng theo customerId
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>customer: 1 khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public Customer GetById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers(int pageSize, int pageIndex)
        {
            var customer = _customerRepository.GetCustomers(pageSize, pageIndex);
            return customer;
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng</param>
        /// <returns>rowAffects: Số dòng DB bị ảnh hưởng khi thêm khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public int InsertCustomer(Customer customer)
        {
            //Validate dữ liệu
            //check trùng mã customerCode
            var customerCode = customer.CustomerCode;
            var checkCustomerCode = _customerRepository.CheckCustomerCodeExists(customerCode);
            
            if (checkCustomerCode)
            {
                var mes = new
                {
                    devMsg = "Duplicate entry CustomerCode.....",
                    userMsg = "CustomerCode đã tồn tại",
                    errorCode = "Mã lội bộ",
                    moreInfo = "Hỗ trợ Dev về lỗi",
                    data = checkCustomerCode,
                    traceId = "Tra cứu thông tin log",
                };
                throw new CustomerExceptions("CustomerCode đã tồn tại trong hệ thống.");
            }
            // - Check các thông tin ko được để trống
            if (string.IsNullOrEmpty(customerCode))
            {
                var mes = new
                {
                    devMsg = "CustomerCode không được phép để trống",
                    userMsg = "Mã khách hàng không được phép để trống",
                    errorCode = "Mã lội bộ",
                    moreInfo = "Hỗ trợ Dev về lỗi",
                    data = customerCode,
                    traceId = "Tra cứu thông tin log",
                };

                throw new CustomerExceptions("Mã khách hàng không được phép để trống");
            }
            var rowAffects = _customerRepository.InsertCustomer(customer);
            return rowAffects;
        }

        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <param name="customer">Khách hàng</param>
        /// <returns>rowAffects: Số dòng DB bị ảnh hưởng khi sửa khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public int UpdateCustomer(Guid customerId, Customer customer)
        {
            // validate dữ liệu
            //check trùng mã customerCode
            var customerCode = customer.CustomerCode;
            var checkCustomerCode = _customerRepository.CheckCustomerCodeExists(customerCode);

            if (checkCustomerCode)
            {
                var mes = new
                {
                    devMsg = "Duplicate entry CustomerCode.....",
                    userMsg = "CustomerCode đã tồn tại",
                    errorCode = "Mã lội bộ",
                    moreInfo = "Hỗ trợ Dev về lỗi",
                    data = checkCustomerCode,
                    traceId = "Tra cứu thông tin log",
                };
                throw new CustomerExceptions("CustomerCode đã tồn tại trong hệ thống.");
            }
            // - Check các thông tin ko được để trống
            if (string.IsNullOrEmpty(customerCode))
            {
                var mes = new
                {
                    devMsg = "CustomerCode không được phép để trống",
                    userMsg = "Mã khách hàng không được phép để trống",
                    errorCode = "Mã lội bộ",
                    moreInfo = "Hỗ trợ Dev về lỗi",
                    data = customerCode,
                    traceId = "Tra cứu thông tin log",
                };

                throw new CustomerExceptions("Mã khách hàng không được phép để trống");
            }
            var rowAffects = _customerRepository.UpdateCustomer(customerId, customer);
            return rowAffects;
        }
    }
}
