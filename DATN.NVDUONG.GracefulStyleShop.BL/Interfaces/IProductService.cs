using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Interfaces
{
    public interface IProductService: IBaseService<Product>
    {
        public ServiceResult Insert(ProductRequest productRequest);
        public bool UpdateSold(Guid productId, int sold);
    }
}
