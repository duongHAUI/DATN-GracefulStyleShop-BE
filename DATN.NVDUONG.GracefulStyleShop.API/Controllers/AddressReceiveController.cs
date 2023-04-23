using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class AddressReceiveController : BaseController<AddressReceive>
    {
        private IAddressReceiveService _addressReceiveService;
        public AddressReceiveController(IAddressReceiveService addressReceiveService) : base(addressReceiveService)
        {
            _addressReceiveService = addressReceiveService;
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPut]
        [Route("Set-Default")]
        public virtual IActionResult SetDefault([FromBody] AddressReceiveSetDefauModel addressReceiveSetDefauModel)
        {
            try
            {
                // Xử lý
                var result = _addressReceiveService.SetDefault(addressReceiveSetDefauModel);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
    }
}
