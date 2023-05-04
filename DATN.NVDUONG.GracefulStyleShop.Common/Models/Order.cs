using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderCode { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string CancelReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid AddressReceiveId { get; set; }
        public Guid ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public string Receiver { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
        public decimal PriceSale { get; set; }
        public Guid OrderDetailId { get; set; }
        public string ImageLink { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
