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
    public class RegionService : IRegionService
    {
        private readonly IRegionDL _regionDL;
        public RegionService(IRegionDL regionDL)
        {
            _regionDL = regionDL;
        }
        public List<Region> getByParentId(int id)
        {
            return _regionDL.getByParentId(id);
        }
    }
}
