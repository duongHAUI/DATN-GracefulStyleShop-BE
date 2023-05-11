using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class SellingProductToMonthNow
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class SellingProductToMonthNowResponse
    {
        public Guid ProductId { get; set; }
        public int totalQuantity { get; set; }
        public string ProductName { get; set; }
    }
}
