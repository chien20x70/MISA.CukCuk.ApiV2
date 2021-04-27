using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseServices<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Lấy tất cả đối tượng.
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        public IEnumerable<MISAEntity> GetAll();

        /// <summary>
        /// Lấy 1 đối tượng theo ID của đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns></returns>
        public MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        public int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng đó</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        public int Update(MISAEntity entity);

        /// <summary>
        /// Xóa 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng class truyền vào</param>
        /// <returns></returns>
        public int Delete(Guid entityId);

        /// <summary>
        /// Phân trang cho đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="pageSize">số đối tượng trong 1 trang</param>
        /// <param name="pageIndex">trang số bao nhiêu</param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetFilter(int pageSize, int pageIndex);
    }
}
