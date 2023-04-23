using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
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
        //private readonly LocalizationService _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IUserRepository _userRepository;
        private readonly IUserTokenService _userService;
        public AuthService(IHttpContextAccessor httpContextAccessor, IUserTokenService userService)
        {
            //_localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
            //_userRepository = userRepository;
            _userService = userService;
        }
        public dynamic AuthenticateUser(LoginRequest loginRequest)
        {
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
            return "";
        }
    }
}
