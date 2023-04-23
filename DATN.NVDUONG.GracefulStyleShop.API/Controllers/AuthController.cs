using DATN.NVDUONG.GracefulStyleShop.API.Hepers;
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [Route("api/authen")]
    [ApiController]
    public class AuthController : MControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] LoginRequest loginRequest)
        {
            string msg = _authService.AuthenticateUser(loginRequest);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("signout")]
        public IActionResult SignOut()
        {

            Response.Cookies.Delete("SetCookieToken");

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
