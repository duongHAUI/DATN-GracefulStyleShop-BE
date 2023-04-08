using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class ProductVariant
    {
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
        public ProductVariant()
        {

        }
        public ProductVariant(Guid productVariantId, int quantity, decimal price, Guid productId, Guid colorId, Guid sizeId)
        {
            this.ProductVariantId = productVariantId;
            this.Quantity = quantity;
            this.Price = price;
            this.ProductId = productId;
            this.ColorId = colorId;
            this.SizeId = sizeId;
        }
        public ProductVariant(Guid productVariantId, int quantity, decimal price, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete, Guid productId, Guid colorId, Guid sizeId)
        {
            ProductVariantId = productVariantId;
            Quantity = quantity;
            Price = price;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
            ProductId = productId;
            ColorId = colorId;
            SizeId = sizeId;
        }
    }
}
