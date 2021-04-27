using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    public class CustomerExceptions : Exception
    {
        public CustomerExceptions(string msg): base(msg)
        {

        }
        public static void CheckCustomerCodeEmpty(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var mes = new
                {
                    devMsg = "CustomerCode không được phép để trống",
                    userMsg = "Mã khách hàng không được phép để trống",
                    errorCode = "Mã lội bộ",
                    moreInfo = "Hỗ trợ Dev về lỗi",
                    data = customerCode,
                    traceId = "Tra cứu thông tin log",
                };

                throw new CustomerExceptions("Mã khách hàng không được phép để trống");
            }
        }
    }
}
