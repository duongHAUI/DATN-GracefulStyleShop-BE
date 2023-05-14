using DATN.NVDUONG.GracefulStyleShop.API.Helpers;
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class StatisticController : Authentication
    {
        #region Field
        protected IStatisticService _statisticService;
        #endregion

        public StatisticController(IStatisticService statisticService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _statisticService = statisticService;
        }
        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpGet("statistic-default")]
        public IActionResult StatisticDefault()
        {
            try
            {
                // Gọi hàm xử lý
                var result = _statisticService.StatisticsDefault();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpPost("SellingProductToMonthNow")]
        public IActionResult SellingProductToMonthNow([FromBody]SellingProductToMonthNow sellingProductToMonthNow)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _statisticService.SellingProductToMonthNow(sellingProductToMonthNow);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpPost("StatisticRevenue")]
        public IActionResult StatisticRevenue([FromBody] SellingProductToMonthNow sellingProductToMonthNow)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _statisticService.StatisticRevenue(sellingProductToMonthNow);
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
