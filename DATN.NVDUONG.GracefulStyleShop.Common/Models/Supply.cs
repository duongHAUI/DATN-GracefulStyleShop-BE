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
        public decimal Price { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Supply()
        {

        }
        public Supply(Guid supplyId, DateTime supplyDate, int quantity, decimal price, Guid supplierId, Guid productVariantId)
        {
            this.SupplyId = supplyId;
            this.SupplyDate = supplyDate;
            this.Quantity = quantity;
            this.Price = price;
            this.SupplierId = supplierId;
            this.ProductVariantId = productVariantId;
        }
    }
}
