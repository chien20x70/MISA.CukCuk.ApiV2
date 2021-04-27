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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupRepository _customerGroupRepository;
        ICustomerGroupServices _customerGroupServices;
        public CustomerGroupController(ICustomerGroupRepository customerGroupRepository,
        ICustomerGroupServices customerGroupServices)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupServices = customerGroupServices;
        }
        /// <summary>
        /// Lấy tất cả customerGroup trong DB
        /// CreatedBy: NXChien (27/04/2021)
        /// </summary>
        /// <returns>Customers: Danh sách CustomerGroup</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customerGroups = _customerGroupRepository.GetAll();
                if (customerGroups.Count() > 0)
                {
                    return Ok(customerGroups);
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
        /// Lấy ra CustomerGroup theo CustomerGroupId
        /// CreatedBy: NXChien (27/04/2021)
        /// </summary>
        /// <param name="customerGroupId">Mã nhóm khách hàng</param>
        /// <returns>Nhóm Khách hàng có mã customerGroupId</returns>
        [HttpGet("{customerGroupId}")]
        public IActionResult Get(Guid customerGroupId)
        {
            try
            {
                var customerGroup = _customerGroupRepository.GetById(customerGroupId);
                if (customerGroup != null)
                {
                    return Ok(customerGroup);
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
        /// CreatedBy: NXChien (27/04/2021)
        /// </summary>
        /// <param name="customerGroup">Khách hàng cần thêm</param>
        /// <returns>
        ///     -StatusCode: thông báo thành công trả về 201
        ///     -NoContent: trả về 204.
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            try
            {
                var rowAffects = _customerGroupServices.Insert(customerGroup);
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
        /// Sửa khách hàng theo customerGroupId
        /// CreatedBy: NXChien (27/04/2021)
        /// </summary>
        /// <param name="customerGroupId">Mã khách hàng</param>
        /// <param name="customerGroup">Khách hàng cần sửa</param>
        /// <returns>
        ///     -Thành công: trả về customerGroup đã sửa.
        ///     -Thất bại: NoContent
        /// </returns>
        [HttpPut("{customerGroupId}")]
        public IActionResult Put(Guid customerGroupId, [FromBody] CustomerGroup customerGroup)
        {
            try
            {
                customerGroup.CustomerGroupId = customerGroupId;
                var rowAffects = _customerGroupServices.Update(customerGroup);
                if (rowAffects > 0)
                {
                    return Ok(customerGroup);
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
        /// CreatedBy: NXChien (27/04/2021)
        /// </summary>
        /// <param name="customerGroupId">Mã Nhóm khách hàng</param>
        /// <returns>
        ///     -Thành công: Xóa thành công.
        ///     -Thất bại: NoContent.
        /// </returns>
        [HttpDelete("{customerGroupId}")]
        public IActionResult Delete(Guid customerGroupId)
        {
            try
            {
                var rowAffects = _customerGroupServices.Delete(customerGroupId);
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
        /// Phân trang cho customerGroup
        /// </summary>
        /// <param name="pageNumber">số đối tượng trong 1 trang</param>
        /// <param name="pageIndex">trang số bao nhiêu</param>
        /// <returns></returns>
        [HttpGet("{pageNumber}/{pageIndex}")]
        public IActionResult Filters(int pageNumber, int pageIndex)
        {
            try
            {
                var customer = _customerGroupServices.GetFilter(pageNumber, pageIndex);
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
