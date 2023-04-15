using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Supply
    {
        public Guid SupplyId { get; set; }
        public DateTime SupplyDate { get; set; }
        public int Quantity { get; set; }
        public decimal PriceSupply { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
    }
}
