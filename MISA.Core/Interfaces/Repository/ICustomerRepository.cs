using MISA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Check CustomerCode đã tồn tại hay chưa
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <param name="isCheck">Check put: false or post: true</param>
        /// <returns></returns>
        public bool CheckCustomerCodeExist(string customerCode, Guid? customerId,bool isCheck);

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại trong DB chưa
        /// CREATED BY: NXCHIEN 27/04/2021
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool CheckPhoneNumberExits(string phoneNumber);

    }
}
