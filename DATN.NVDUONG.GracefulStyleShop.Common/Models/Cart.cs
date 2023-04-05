using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Cart()
        {

        }
        public Cart(Guid cartId, int quantity, Guid customerId, Guid productVariantId)
        {
            this.CartId = cartId;
            this.Quantity = quantity;
            this.CustomerId = customerId;
            this.ProductVariantId = productVariantId;
        }
        public Cart(Guid cartId, int quantity, DateTime createdAt, DateTime modifiedAt, Guid customerId, Guid productVariantId)
        {
            CartId = cartId;
            Quantity = quantity;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            CustomerId = customerId;
            ProductVariantId = productVariantId;
        }
    }
}
