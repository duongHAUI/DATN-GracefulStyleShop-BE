using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    public interface IProductDL : IBaseDL<Product>
    {
        public bool UpdateSold(Guid productId, int sold);
        public PagingResult<object> GetByFilterDetail(dynamic parametersFilter);
        public object GetByIDDetail(Guid id);
    }
}
