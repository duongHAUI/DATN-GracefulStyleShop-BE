using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class CartController : BaseController<Cart>
    {
        private IBaseService<Cart> _baseService;
        public CartController(IBaseService<Cart> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
