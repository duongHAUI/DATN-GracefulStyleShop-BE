using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class ShipmentController : BaseController<Shipment>
    {
        private IBaseService<Shipment> _baseService;
        public ShipmentController(IBaseService<Shipment> baseService, IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
