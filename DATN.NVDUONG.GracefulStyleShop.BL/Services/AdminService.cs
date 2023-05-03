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
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService(IBaseDL<Admin> baseDL) : base(baseDL)
        {
        }

        public override Admin processPropertyCustom(Admin admin, bool isInsert)
        {
            if (isInsert)
            {
                admin.Password= DATN.NVDUONG.GracefulStyleShop.Commons.Commons.MD5Hash("12345678@Abc");
            }

            return admin;
        }
    }
}
