using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.ApiV2.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        /// <summary>
        /// Khởi tạo các kết nối tới interfaces
        /// </summary>
        /// CreatedBy: NXChien (21/04/2021)
        ICustomerRepository _customerRepository;
        ICustomerServices _customerServices;
        public CustomerController(ICustomerRepository customerRepository, ICustomerServices customerServices)
        {
            _customerRepository = customerRepository;
            _customerServices = customerServices;
        }

        /// <summary>
        /// Lấy tất cả khách hàng trong DB
        /// </summary>
        /// <returns>Customers: Danh sách khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                if (customers.Count() > 0)
                {
                    return Ok(customers);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lấy ra khách hàng theo CustomerId
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>customer: Khách hàng có mã customerId</returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            try
            {
                var customer = _customerRepository.GetById(customerId);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng cần thêm</param>
        /// <returns>
        ///     -StatusCode: thông báo thành công trả về 201
        ///     -NoContent: trả về 204.
        /// </returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                var rowAffects = _customerServices.InsertCustomer(customer);
                if (rowAffects > 0)
                {
                    return StatusCode(201, rowAffects);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sửa khách hàng theo customerId
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <param name="customer">Khách hàng cần sửa</param>
        /// <returns>
        ///     -Thành công: trả về customer đã sửa.
        ///     -Thất bại: NoContent
        /// </returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpPut("{customerId}")]
        public IActionResult Put(Guid customerId, [FromBody] Customer customer)
        {
            try
            {
                var rowAffects = _customerServices.UpdateCustomer(customerId, customer);
                if (rowAffects > 0)
                {
                    return Ok(customer);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>
        ///     -Thành công: Xóa thành công.
        ///     -Thất bại: NoContent.
        /// </returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            try
            {
                var rowAffects = _customerServices.DeleteCustomer(customerId);
                if (rowAffects > 0)
                {
                    return Ok("Xoa thanh cong");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lọc danh sách khách hàng
        /// </summary>
        /// <param name="pageNumber">Số khách hàng trong 1 trang</param>
        /// <param name="pageIndex">Trang số bao nhiêu</param>
        /// <returns></returns>
        /// Created By: NXChien 22/04/2021
        [HttpGet("{pageNumber}/{pageIndex}")]
        public IActionResult Filters(int pageNumber, int pageIndex)
        {
            try
            {
                var customer = _customerServices.GetCustomers(pageNumber, pageIndex);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
