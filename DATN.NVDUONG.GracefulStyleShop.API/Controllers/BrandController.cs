using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class BrandController : BaseController<Brand>
    {
        private IBaseService<Brand> _baseService;
        public BrandController(IBaseService<Brand> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
