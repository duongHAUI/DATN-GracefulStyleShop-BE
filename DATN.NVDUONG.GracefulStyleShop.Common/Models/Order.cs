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
        public string Status { get; set; }
        public string CancelReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid AddressReceiveId { get; set; }
        public Guid ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public string Receiver { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
