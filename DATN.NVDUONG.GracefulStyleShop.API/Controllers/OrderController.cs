using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class OrderController : BaseController<Order>
    {
        private IBaseService<Order> _baseService;
        public OrderController(IBaseService<Order> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
