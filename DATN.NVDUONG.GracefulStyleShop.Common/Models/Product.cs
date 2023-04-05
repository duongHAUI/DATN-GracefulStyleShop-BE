using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Sold { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid TypeId { get; set; }
        public Guid BrandId { get; set; }
    }

    public class ProductRequest
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Sold { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid TypeId { get; set; }
        public Guid BrandId { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
