using DATN.NVDUONG.GracefulStyleShop.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        [DisplayName("Họ tên")]
        [CustomRequired]
        public string FullName { get; set; }
        [DisplayName("Email")]
        [CustomRegularExpression("")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        [CustomRegularExpression("")]
        public string Phone { get; set; }
        [CustomRequired]
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
