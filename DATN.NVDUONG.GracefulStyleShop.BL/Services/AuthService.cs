using DATN.NVDUONG.GracefulStyleShop.API.Common;
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Enums;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using DATN.NVDUONG.GracefulStyleShop.Common.Resources;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.DL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserTokenDL _userTokenDL;
        private readonly ICustomerDL _customerDL;
        public AuthService(IUserTokenDL userTokenDL, ICustomerDL customerDL)
        {
            _userTokenDL = userTokenDL;
            _customerDL = customerDL;
        }
        public dynamic AuthenticateUser(LoginRequest loginRequest)
        {
            dynamic result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer); ;
            // trả về lỗi validate
            dynamic validationResults = null;
            var listErrorValidate = new Dictionary<string, string>();
            // Kiểm tra attribute hợp lệ của dữ liệu
            if (!Validator.TryValidateObject(loginRequest, new ValidationContext(loginRequest), validationResults, true))
            {
                foreach (var item in validationResults)
                {
                    listErrorValidate.Add(item.MemberNames.First(), item.ErrorMessage is null ? "" : item.ErrorMessage);
                }
            }

            if(loginRequest.RoleType == EnumRole.Customer)
            {
                var password = Commons.Commons.MD5Hash(loginRequest.Password);

                var customer = _customerDL.getByEmailAndPassword(loginRequest.Email, password);
                if (customer == null)
                {
                    listErrorValidate.Add("LoginError","Tài khoản hoặc mật khẩu không chính xác.!");
                    result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
                }
                else
                {
                    UserToken userToken = CacheUserToken.CreateToken(customer);

                    var response = _userTokenDL.Insert(userToken);
                    if (!response)
                        result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                    customer.Password = "";

                    result = new ServiceResult(new
                    {
                        Token = userToken.Token,
                        Customer = customer,
                    });
                }
            }

            return result;
        }
    }
}
