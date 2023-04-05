using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class SupplyController : BaseController<Supply>
    {
        private IBaseService<Supply> _baseService;
        public SupplyController(IBaseService<Supply> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
