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
    }
}
