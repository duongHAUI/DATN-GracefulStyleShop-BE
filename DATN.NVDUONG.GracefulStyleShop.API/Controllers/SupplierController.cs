﻿using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.NVDUONG.GracefulStyleShop.API.Controllers
{
    public class SupplierController : BaseController<Supplier>
    {
        private IBaseService<Supplier> _baseService;
        public SupplierController(IBaseService<Supplier> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
