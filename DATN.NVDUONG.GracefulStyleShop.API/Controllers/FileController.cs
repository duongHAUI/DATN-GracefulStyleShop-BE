using DATN.NVDUONG.GracefulStyleShop.API.Hepers;
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController : MControllerBase
    {
        private IFile _file;
        public FileController(IFile file)
        {
            _file = file;
        }
        [HttpPost]
        public IActionResult Insert([FromForm] FileModel fileModel)
        {
            try
            {
                // Xử lý
                var result = _file.Insert(fileModel);

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
