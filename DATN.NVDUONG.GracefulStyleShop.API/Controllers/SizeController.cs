
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class SizeController : BaseController<Size>
    {
        private IBaseService<Size> _baseService;
        public SizeController(IBaseService<Size> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
