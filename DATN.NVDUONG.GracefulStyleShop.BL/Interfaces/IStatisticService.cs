using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Interfaces
{
    public interface IStatisticService
    {
        public object StatisticsDefault();
        public object SellingProductToMonthNow(SellingProductToMonthNow sellingProductToMonthNow);
        public List<StatisticRevenueResponse> StatisticRevenue(SellingProductToMonthNow sellingProductToMonthNow);
    }
}
