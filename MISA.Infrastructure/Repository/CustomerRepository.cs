using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// kiểm tra trùng mã khach hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Trùng thì trả về TRUE</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public bool CheckCustomerCodeExists(string customerCode)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("ConnectionDB"));
            var sqlCommandDuplicate = "Proc_CheckCustomerCodeExists";
            var check = dbConnection.QueryFirstOrDefault<bool>
                (sqlCommandDuplicate, param: new { m_CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            return check;
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>rowAffects: Số dòng bị ảnh hướng khi xóa</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public int DeleteCustomer(Guid customerId)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            string sql = "Proc_DeleteCustomer";
            var rowAffects = dbConnection.Execute(sql, param: new { CustomerId = customerId }, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Lấy tất cả khách hàng trong DB
        /// </summary>
        /// <returns>customers: Danh sách khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public IEnumerable<Customer> GetAll()
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            string sql = "Proc_GetCustomers";
            var customer = dbConnection.Query<Customer>(sql, commandType: CommandType.StoredProcedure);
            return customer;
        }

        /// <summary>
        /// Lấy khách hàng theo customerId
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>customer: 1 khách hàng</returns>
        /// CreatedBy: NXChien (21/04/2021)
        public Customer GetById(Guid customerId)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            string sql = "Proc_GetCustomerById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>(sql, parameters, commandType: CommandType.StoredProcedure);
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
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            string sql = "Proc_InsertCustomer";
            var rowAffects = dbConnection.Execute(sql, customer, commandType: CommandType.StoredProcedure);
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
            customer.CustomerId = customerId;
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            string sql = "Proc_UpdateCustomer";
            var rowAffects = dbConnection.Execute(sql, param: customer, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
    }
}
