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
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng class truyền vào</param>
        /// <returns></returns>
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        /// <summary>
        /// Lấy tất cả đối tượng.
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID của đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns></returns>
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        public int Insert(MISAEntity entity)
        {
            // validate data
            Validate(entity);
            return _baseRepository.Insert(entity);
        }

        protected virtual void Validate(MISAEntity entity)
        {

        }

        /// <summary>
        /// Sửa 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng đó</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        /// <summary>
        /// Phân trang cho đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="pageSize">số đối tượng trong 1 trang</param>
        /// <param name="pageIndex">trang số bao nhiêu</param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetFilter(int pageSize, int pageIndex)
        {
            return _baseRepository.GetFilter(pageSize, pageIndex);
        }
    }
}
