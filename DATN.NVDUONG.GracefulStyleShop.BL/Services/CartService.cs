using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class CartService : BaseService<Cart>, ICartService
    {
        private ICartDL _cartDL;
        public CartService(ICartDL cartDL) : base(cartDL)
        {
            _cartDL = cartDL;
        }

        public int CartNumber(Guid CustomerId)
        {
            return _cartDL.CartNumber(CustomerId);
        }

        public override object GetByFilter(object parameters)
        {
            return _cartDL.GetByFilter(parameters);
        }
        public bool UpdateQuantity(Guid id, int quantity)
        {
            return _cartDL.UpdateQuantity(id, quantity);
        }
    }
}
