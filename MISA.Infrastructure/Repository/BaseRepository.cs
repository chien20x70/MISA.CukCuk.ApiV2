using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        protected string ConnectionDB = "Host=47.241.69.179;User Id=dev;Password=12345678;Database=MF0_NVManh_CukCuk02; Convert Zero Datetime=true;";
        string tableName = typeof(MISAEntity).Name;
        protected IDbConnection dbConnection;

        /// <summary>
        /// Xóa entity
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng class truyền vào</param>
        /// <returns></returns>
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Delete{tableName}";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var rowAffects = dbConnection.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }
        }

        /// <summary>
        /// Lấy tất cả đối tượng.
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Get{tableName}s";
                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add($"@{tableName}Id", entytiId);
                var entities = dbConnection.Query<MISAEntity>(sql, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID của đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns></returns>
        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Get{tableName}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns>số dòng bị ảnh hưởng trong DB</returns>
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Insert{tableName}";
                var rowAffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }
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
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Update{tableName}";
                var rowAffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }
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
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                string sql = $"Proc_Get{tableName}Paging";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@m_PageIndex", pageIndex);
                parameters.Add("@m_PageSize", pageSize);
                var entities = dbConnection.Query<MISAEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
    }
}
