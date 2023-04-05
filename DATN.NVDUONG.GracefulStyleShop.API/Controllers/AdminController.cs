using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class AdminController : BaseController<Admin>
    {
        private IBaseService<Admin> _baseService;
        public AdminController(IBaseService<Admin> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
