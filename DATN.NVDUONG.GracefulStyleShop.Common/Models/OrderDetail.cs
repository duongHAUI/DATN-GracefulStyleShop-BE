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
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public OrderDetail()
        {

        }
        public OrderDetail(Guid orderDetailId, int quantity, decimal price, Guid orderId, Guid productVariantId)
        {
            this.OrderDetailId = orderDetailId;
            this.Quantity = quantity;
            this.Price = price;
            this.OrderId = orderId;
            this.ProductVariantId = productVariantId;
        }
        public OrderDetail(Guid orderDetailId, int quantity, decimal price, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete, Guid orderId, Guid productVariantId)
        {
            OrderDetailId = orderDetailId;
            Quantity = quantity;
            Price = price;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
            OrderId = orderId;
            ProductVariantId = productVariantId;
        }
    }
}
