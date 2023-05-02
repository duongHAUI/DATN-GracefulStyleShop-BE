using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    public interface ICartDL : IBaseDL<Cart>
    {
        public int CartNumber(Guid CustomerId);

        public bool UpdateQuantity(Guid id, int quantity);
    }
}
