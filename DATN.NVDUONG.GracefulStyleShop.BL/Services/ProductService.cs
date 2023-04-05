using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductDL _productDL;
        public ProductService(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }

        public bool UpdateSold(Guid productId, int sold)
        {
            return _productDL.UpdateSold(productId, sold);
        }

        ServiceResult IProductService.Insert(ProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
