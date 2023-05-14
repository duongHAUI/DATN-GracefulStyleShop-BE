namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Product : Image
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Sold { get; set; }
        public int Quantity { get; set; }
        public bool IsMassDiscount { get; set; }
        public int MassDiscount { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public decimal PriceSale { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public decimal PriceDel
        {
            get
            {
                return PriceSale * (decimal)(1 -(IsMassDiscount ? MassDiscount :Discount) * 0.01);
            }
            set
            {
                value = PriceDel;
            }
        }
    }

    public class ProductDB : Product
    {
        public Guid ProductVariantId { get; set; }
        public int ProductVariantQuantity { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorName { get; set; }
        public int ProVariantQuantity { get; set; }
    }

    public class MassDiscountBrand
    {
        public Guid BrandId { get; set; }
    }
    public class MassDiscountType
    {
        public Guid TypeId { get; set; }
    }
}
