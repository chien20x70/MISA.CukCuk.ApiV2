using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        IBaseServices<MISAEntity> _baseServices;
        string tableName = typeof(MISAEntity).Name;
        public BaseController(IBaseRepository<MISAEntity> baseRepository, IBaseServices<MISAEntity> baseServices)
        {
            _baseRepository = baseRepository;
            _baseServices = baseServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _baseRepository.GetAll();
                if (entities.Count() > 0)
                {
                    return Ok(entities);
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
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            try
            {
                var entity = _baseRepository.GetById(entityId);
                if (entity != null)
                {
                    return Ok(entity);
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
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {
                var rowAffects = _baseServices.Insert(entity);
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
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, [FromBody] MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var item in properties)
            {
                var propertyName = item.Name;
                if (propertyName == $"{tableName}Id")
                {
                    item.SetValue(entity, entityId);
                    
                }
            }
                try
            {
                var rowAffects = _baseServices.Update(entity);
                if (rowAffects > 0)
                {
                    return Ok(entity);
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
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var rowAffects = _baseServices.Delete(entityId);
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
        [HttpGet("Paging")]
        public IActionResult Filters(int pageNumber, int pageIndex)
        {
            try
            {
                var entity = _baseServices.GetFilter(pageNumber, pageIndex);
                if (entity != null)
                {
                    return Ok(entity);
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
