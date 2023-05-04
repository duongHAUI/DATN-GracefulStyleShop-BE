using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderDL _orderDL;
        public OrderService(IOrderDL orderDL) : base(orderDL)
        {
            _orderDL = orderDL;
        }

        public override Order processPropertyCustom(Order order,bool IsInsert)
        {

            Random random = new Random();
            string orderDetailCode = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            order.OrderCode = orderDetailCode;
            order.OrderDetails.ForEach(d =>
            {
                d.CreatedAt = DateTime.Now;
                d.OrderId = order.OrderId;
                d.OrderDetailId = Guid.NewGuid();
            });
            return order;
        }

        public ServiceResult Insert(Order order,Guid customerId)
        {
            dynamic result;
            var isValid = this.IsValidate(order);

            // Kiểm tra validate
            if (isValid)
            {
                order = AddProperties(order, true, null, out Guid id);

                bool response = _orderDL.Insert(order, order.OrderDetails,customerId);
                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);
                else result = new ServiceResult(id);
            }
            else
            {
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }
    }
}
