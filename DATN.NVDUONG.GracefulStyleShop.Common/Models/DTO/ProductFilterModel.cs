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
}
