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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerDL _customerDL;
        public CustomerService(ICustomerDL customerDL) : base(customerDL)
        {
            _customerDL = customerDL;
        }

        public override void ValidateCustom(Customer entity, bool isInsert = true)
        {
            base.ValidateCustom(entity, isInsert);
        }

        protected override Customer processPropertyCustom(Customer entity)
        {
            return base.processPropertyCustom(entity);
        }
    }
}
