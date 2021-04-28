using MISA.Core.CustomAttribute;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseServices<MISAEntity> : IBaseServices<MISAEntity> where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseServices(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="entityId">ID của đối tượng class truyền vào</param>
        /// <returns></returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        /// <summary>
        /// Lấy tất cả đối tượng.
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID của đối tượng
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns></returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        /// 
        public int Insert(MISAEntity entity)
        {
            //TODO: validate data Insert
            Validate(entity, true);
            return _baseRepository.Insert(entity);
        }

        /// <summary>
        /// Validate dữ liệu. 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCheckPutOrPost">: true thì là Post : false thì là Put</param>
        protected virtual void CustomValidate(MISAEntity entity, bool isCheckPutOrPost)
        {
            
        }
        private void Validate(MISAEntity entity, bool isCheckPutOrPost)
        {
            // Lấy ra tất cả property của đối tượng
            var properties = typeof(MISAEntity).GetProperties();
            //duyệt tất cả property của đối tượng
            foreach (var property in properties)
            {
                // gán các attributeCustom cho requiredP
                var requiredProperty = property.GetCustomAttributes(typeof(MISARequired), true);
                // Kiểm tra các trường trống
                if (requiredProperty.Length > 0)
                {
                    // Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    // Kiểm tra giá trị
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requiredProperty[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"Thông tin {property.Name} không được phép để trống!";
                        }
                        throw new CustomerExceptions(msgError);
                    }
                }
                // Kiểm tra .... 
            }
            CustomValidate(entity, isCheckPutOrPost);
        }

        /// <summary>
        /// Sửa 1 đối tượng
        /// </summary>
        /// <param name="entityId">ID của đối tượng đó</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        public int Update(MISAEntity entity)
        {
            //TODO: validate data PUT
            Validate(entity, false);
            return _baseRepository.Update(entity);
        }

        /// <summary>
        /// Phân trang cho đối tượng
        /// </summary>
        /// <param name="pageSize">số đối tượng trong 1 trang</param>
        /// <param name="pageIndex">trang số bao nhiêu</param>
        /// <returns></returns>
        /// CREATED BY: NXCHIEN 27/04/2021
        public IEnumerable<MISAEntity> GetFilter(int pageSize, int pageIndex)
        {
            return _baseRepository.GetFilter(pageSize, pageIndex);
        }
    }
}
