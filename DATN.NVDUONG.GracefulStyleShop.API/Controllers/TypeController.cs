using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class TypeController : BaseController<DATN.NVDUONG.GracefulStyleShop.Common.Models.Type>
    {
        private IBaseService<DATN.NVDUONG.GracefulStyleShop.Common.Models.Type> _baseService;
        public TypeController(IBaseService<DATN.NVDUONG.GracefulStyleShop.Common.Models.Type> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
