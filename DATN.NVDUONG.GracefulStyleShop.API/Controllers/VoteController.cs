using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class VoteController : BaseController<Vote>
    {
        private IBaseService<Vote> _baseService;
        public VoteController(IBaseService<Vote> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
