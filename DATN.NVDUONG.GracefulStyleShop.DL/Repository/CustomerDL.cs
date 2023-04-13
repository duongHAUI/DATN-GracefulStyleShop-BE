using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class CustomerDL : BaseDL<Customer>, ICustomerDL
    {
        public CustomerDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public Customer getByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
