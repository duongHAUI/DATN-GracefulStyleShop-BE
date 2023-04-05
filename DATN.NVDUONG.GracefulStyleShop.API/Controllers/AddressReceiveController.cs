using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class AddressReceiveController : BaseController<AddressReceive>
    {
        private IBaseService<AddressReceive> _baseService;
        public AddressReceiveController(IBaseService<AddressReceive> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
