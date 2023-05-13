using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Interfaces
{
    public interface ICreditCardService
    {
        public Task<Dictionary<string, string>> Checkout(CreditCardInfo creditCardInfor);
    }
}
