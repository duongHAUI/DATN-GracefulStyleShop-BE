using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    public interface IStatisticDL
    {
        public object StatisticsDefault();
        public object SellingProductToMonthNow(SellingProductToMonthNow sellingProductToMonthNow);
    }
}
