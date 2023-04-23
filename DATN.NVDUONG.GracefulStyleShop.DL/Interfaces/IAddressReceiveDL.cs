using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Interfaces
{
    public interface IAddressReceiveDL : IBaseDL<AddressReceive>
    {
        public bool SetDefault(AddressReceiveSetDefauModel addressReceiveSetDefauModel);
    }
}
