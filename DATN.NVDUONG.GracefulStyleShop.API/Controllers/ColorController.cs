using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ColorController : BaseController<Color>
    {
        private IBaseService<Color> _baseService;
        public ColorController(IBaseService<Color> baseService) :base(baseService)
        {
            _baseService = baseService;
        }
    }
}
