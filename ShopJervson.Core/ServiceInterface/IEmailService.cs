using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Dto;

namespace ShopJervson.Core.ServiceInterface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto dto);
    }
}
