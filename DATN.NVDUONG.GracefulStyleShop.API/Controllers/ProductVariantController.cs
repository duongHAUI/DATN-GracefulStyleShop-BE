using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ProductVariantController : BaseController<ProductVariant>
    {
        public ProductVariantController(IBaseService<ProductVariant> baseService) : base(baseService)
        {
        }
    }
}
