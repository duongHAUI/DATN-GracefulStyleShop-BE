
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class SizeController : BaseController<Size>
    {
        private IBaseService<Size> _baseService;
        public SizeController(IBaseService<Size> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
