﻿using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class OrderDetailController : BaseController<OrderDetail>
    {
        private IBaseService<OrderDetail> _baseService;
        public OrderDetailController(IBaseService<OrderDetail> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
