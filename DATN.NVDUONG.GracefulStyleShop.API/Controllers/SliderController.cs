using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class SliderController : BaseController<Slider>
    {
        private IBaseService<Slider> _baseSerive;
        public SliderController(IBaseService<Slider> baseSerive, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseSerive, httpContextAccessor, userTokenService)
        {
            _baseSerive = baseSerive;
        }
      
    }
}
