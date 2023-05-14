using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class StatisticService : IStatisticService
    {
        private IStatisticDL _statisticDL;
        public StatisticService(IStatisticDL statisticDL)
        {
            _statisticDL = statisticDL;
        }

        public object SellingProductToMonthNow(SellingProductToMonthNow sellingProductToMonthNow)
        {
            return _statisticDL.SellingProductToMonthNow(sellingProductToMonthNow);
        }

        public List<StatisticRevenueResponse> StatisticRevenue(SellingProductToMonthNow sellingProductToMonthNow)
        {
            var res = _statisticDL.StatisticRevenue(sellingProductToMonthNow);
            var result = new List<StatisticRevenueResponse>();
            for (int i = 1; i <= 12; i++)
            {
                var month = new StatisticRevenueResponse();
                var revenueMonth = res.Find(x => x.Month == i);
                if (revenueMonth != null)
                {
                    month.TotalPrice = revenueMonth.TotalPrice;
                    month.Month = i;
                    month.MonthTitle = "Tháng "+ i;
                }
                else
                {
                    month.TotalPrice = 0;
                    month.Month = i;
                    month.MonthTitle = "Tháng " + i;
                }
                result.Add(month);
            }

            return result;
        }

        public object StatisticsDefault()
        {
            return _statisticDL.StatisticsDefault();
        }
    }
}
