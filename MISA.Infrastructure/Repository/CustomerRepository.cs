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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        /// <summary>
        /// Check CustomerCode đã tồn tại hay chưa
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns></returns>
        public bool CheckCustomerCodeExist(string customerCode)
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                var sqlCommandDuplicate = "Proc_CheckCustomerCodeExists";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@m_CustomerCode", customerCode);
                var check = dbConnection.QueryFirstOrDefault<bool>
                    (sqlCommandDuplicate, param: parameters, commandType: CommandType.StoredProcedure);
                return check;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại trong DB chưa
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool CheckPhoneNumberExits(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(ConnectionDB))
            {
                var sqlCommandDuplicate = "Proc_CheckPhoneNumberExists";
                var check = dbConnection.QueryFirstOrDefault<bool>
                    (sqlCommandDuplicate, param: new { m_PhoneNumber = phoneNumber }, commandType: CommandType.StoredProcedure);
                return check;
            }
        }
    }
}
