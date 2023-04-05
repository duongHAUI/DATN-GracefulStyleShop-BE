using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid OrderId { get; set; }
        public Shipment()
        {

        }
        public Shipment(Guid shipmentId, string method, DateTime date, decimal price, Guid orderId)
        {
            this.ShipmentId = shipmentId;
            this.Method = method;
            this.Date = date;
            this.Price = price;
            this.OrderId = orderId;
        }
        public Shipment(Guid shipmentId, string method, DateTime date, decimal price, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete, Guid orderId)
        {
            ShipmentId = shipmentId;
            Method = method;
            Date = date;
            Price = price;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
            OrderId = orderId;
        }
    }
}
