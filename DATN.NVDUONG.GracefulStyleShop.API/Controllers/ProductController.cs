using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private IProductService _productService;
        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(productService, httpContextAccessor, userTokenService)
        {
            _productService = productService;
        }

        [HttpPut]
        [Route("Update-Sold/{id}")]
        public IActionResult UpdateSold([FromRoute] Guid id, [FromBody] int sold)
        {
            try
            {
                bool result = _productService.UpdateSold(id, sold);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [Authorize(Policy = "AllowAnonymousPolicy")]
        [HttpPost]
        [Route("Filter-Detail")]
        public virtual IActionResult GetByFilterDetail([FromBody] ProductFilterModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _productService.GetByFilterDetail(paramFilter);

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

        /// <summary>
        /// Lấy thông tin theo ID
        /// </summary>
        /// <param name="id">ID muốn lấy</param>
        /// <returns>Thông tin theo ID</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult GetByIDDetail([FromRoute] Guid id)
        {
            try
            {
                // Xử lý
                var result = _productService.GetByIDDetail(id);

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

        [AllowAnonymous]
        [HttpPut]
        [Route("Mass-Discount")]
        public IActionResult MassDiscount(MassDiscountModel massDiscountModel)
        {
            try
            {
                // Xử lý
                var result = _productService.MassDiscount(massDiscountModel);

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

        [AllowAnonymous]
        [HttpGet]
        [Route("Get-Mass-Discount")]
        public IActionResult GetMassDiscount()
        {
            try
            {
                // Xử lý
                var result = _productService.GetMassDiscount();

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
