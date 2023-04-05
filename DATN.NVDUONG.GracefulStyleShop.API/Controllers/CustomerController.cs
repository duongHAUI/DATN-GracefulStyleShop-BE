using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        private IBaseService<Customer> _baseService;
        public CustomerController(IBaseService<Customer> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
