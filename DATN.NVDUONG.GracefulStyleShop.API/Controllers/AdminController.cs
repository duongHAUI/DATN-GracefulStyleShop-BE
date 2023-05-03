using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class AdminController : BaseController<Admin>
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService, IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService) : base(adminService, httpContextAccessor, userTokenService)
        {
            _adminService = adminService;
        }
    }
}
