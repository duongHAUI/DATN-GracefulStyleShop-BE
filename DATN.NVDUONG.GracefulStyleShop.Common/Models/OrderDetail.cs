using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceSale { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ImageLink { get; set; }

        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
    }
}
