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
        public int Quantity { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string CancelReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid AddressReceiveId { get; set; }
        public Order()
        {

        }
        public Order(Guid orderId, int quantity, string status)
        {
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.Status = status;
        }
        public Order(Guid orderId, int quantity, string note, string status, string cancelReason, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete, Guid addressReceiveId) : this(orderId, quantity, note)
        {
            Status = status;
            CancelReason = cancelReason;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
            AddressReceiveId = addressReceiveId;
        }
    }
}
