using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class ProductVariantController : BaseController<ProductVariant>
    {
        private IBaseService<ProductVariant> _baseService;
        public ProductVariantController(IBaseService<ProductVariant> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
