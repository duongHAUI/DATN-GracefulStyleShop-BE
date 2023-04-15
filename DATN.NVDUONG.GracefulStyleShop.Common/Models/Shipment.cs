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
        public int DateFrom { get; set; }
        public int DateTo { get; set; }
        public decimal PriceShip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string DateReceive
        {
            get
            {
                return DateFrom + " - " + DateTo + " ngày";
            }
        }
    }
}
