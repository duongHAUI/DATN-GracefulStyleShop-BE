using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class AddressReceive
    {
        public Guid AddressReceiveId { get; set; }
        public string Receiver { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
        public int ProvinceID { get; set; }
        public int WardID { get; set; }
        public int DistrictID { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsDefault { get; set; }
    }

}
