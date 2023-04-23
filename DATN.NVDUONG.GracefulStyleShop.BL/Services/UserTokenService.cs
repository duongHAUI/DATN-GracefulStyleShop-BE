using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class UserTokenService : IUserTokenService
    {
        private IUserTokenDL _userTokenDL;
        public UserTokenService(IUserTokenDL userTokenDL)
        {
            _userTokenDL = userTokenDL;
        }

        public UserToken GetUserByToken(string token)
        {
            return _userTokenDL.GetUserByToken(token);
        }
    }
}
