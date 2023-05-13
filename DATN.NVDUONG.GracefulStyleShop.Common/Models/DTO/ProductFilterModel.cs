using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO
{
    public class ProductFilterModel : PagingModel
    {
        public int FilterType { get; set; }
    }

    public class MassDiscountModel
    {
        public List<Guid> Brands { get; set; }
        public List<Guid> Types { get; set; }
        public int DiscountNumber { get; set; }
    }
}
