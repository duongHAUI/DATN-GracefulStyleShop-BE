using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
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
        public object StatisticsDefault()
        {
            return _statisticDL.StatisticsDefault();
        }
    }
}
