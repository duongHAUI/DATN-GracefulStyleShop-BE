using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private IProductService _productService;
        public ProductController(IProductService productService) : base(productService)
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
    }
}
