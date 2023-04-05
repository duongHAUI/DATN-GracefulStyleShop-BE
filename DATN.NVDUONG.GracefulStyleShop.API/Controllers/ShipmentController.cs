using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ShipmentController : BaseController<Shipment>
    {
        private IBaseService<Shipment> _baseService;
        public ShipmentController(IBaseService<Shipment> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
