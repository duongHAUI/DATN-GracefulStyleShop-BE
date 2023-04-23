using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace DATN.NVDUONG.GracefulStyleShop.API.Common
{
    public static class CacheUserToken
    {
        const int HOUR_TIMEOUT_TOKEN = 24 * 2;
        const int HOUR_TIMEOUT_TOKEN_REMEMBER = 24 * 7;
        public static string GetTokenFromRequest(HttpRequest request)
        {
            string token = "";
            if (request == null) return "request == null";

            if (string.IsNullOrEmpty(request.Headers["Authorization"])) return "";
            token = request.Headers["Authorization"].ToString().Replace("Bearer ","");

            return token;
        }
        public static UserToken CreateToken(Customer customer, string ipAddress = "", bool IsRememberPassword = false)
        {
            string msg;
            string token;

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())); // Sau phát triển thêm cả chữ ký vào
                token = Convert.ToBase64String(hashedBytes);
            }

            var userToken = new UserToken
            {
                UserTokenId = Guid.NewGuid(),
                UserID = customer.CustomerId,
                IsRememberPassword = IsRememberPassword,
                Token = token,
                ExpiredAt = DateTime.Now.AddHours(IsRememberPassword ? HOUR_TIMEOUT_TOKEN_REMEMBER : HOUR_TIMEOUT_TOKEN),
                CreatedAt = DateTime.Now,
                IpAddress = ipAddress,
                Username = customer.FullName,
            };

            //UserToken.ID = newID.ToGuid(new Guid());
            //UserToken.TimeUpdateExpiredDateToDB = DateTime.Now;

            //// Trường hợp setting redis làm cache: 0 (không dùng) 1 (có dùng)
            //if (Common.GetSettingWithDefault("IS_REDIS", "0") == "1")
            //{
            //    // Lưu vào cache
            //    RCache.SetData($"{RConstant.USER_TOKEN_KEY}:{UserToken.Token}", UserToken, 36000);
            //    return "";
            //}
            //if (CacheUserToken.LtUser_Token == null || CacheUserToken.LtUser_Token.Count == 0)
            //{
            //    msg = GetAllToken();
            //    if (msg.Length > 0) return msg;
            //}
            //LtUser_Token.Add(UserToken);

            return userToken;
        }
        public static UserToken CreateToken(Admin admin, string ipAddress = "", bool IsRememberPassword = false)
        {
            string msg;
            var userToken = new UserToken
            {
                UserTokenId = Guid.NewGuid(),
                UserID = admin.AdminId,
                IsRememberPassword = IsRememberPassword,
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                ExpiredAt = DateTime.Now.AddHours(IsRememberPassword ? HOUR_TIMEOUT_TOKEN_REMEMBER : HOUR_TIMEOUT_TOKEN),
                CreatedAt = DateTime.Now,
                IpAddress = ipAddress,
                Username = admin.FullName
            };

            //UserToken.ID = newID.ToGuid(new Guid());
            //UserToken.TimeUpdateExpiredDateToDB = DateTime.Now;

            //// Trường hợp setting redis làm cache: 0 (không dùng) 1 (có dùng)
            //if (Common.GetSettingWithDefault("IS_REDIS", "0") == "1")
            //{
            //    // Lưu vào cache
            //    RCache.SetData($"{RConstant.USER_TOKEN_KEY}:{UserToken.Token}", UserToken, 36000);
            //    return "";
            //}
            //if (CacheUserToken.LtUser_Token == null || CacheUserToken.LtUser_Token.Count == 0)
            //{
            //    msg = GetAllToken();
            //    if (msg.Length > 0) return msg;
            //}
            //LtUser_Token.Add(UserToken);

            return userToken;
        }
    }
}
