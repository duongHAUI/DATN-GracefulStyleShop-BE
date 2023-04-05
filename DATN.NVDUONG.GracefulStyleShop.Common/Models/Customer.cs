using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Customer()
        {

        }
        public Customer(Guid customerId, string customerName, string email, string password)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.Email = email;
            this.Password = password;
        }
        public Customer(Guid customerId, string customerName, string email, string password, string image, DateTime createdAt, DateTime modifiedAt, bool isActive, bool isDelete) : this(customerId, customerName, email, password)
        {
            Image = image;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IsActive = isActive;
            IsDelete = isDelete;
        }
    }
}
