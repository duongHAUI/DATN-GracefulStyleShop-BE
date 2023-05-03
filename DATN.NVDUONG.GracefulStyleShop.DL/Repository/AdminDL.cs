using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class AdminDL : BaseDL<Admin>,IAdminDL
    {
        public AdminDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public Admin getByEmailAndPassword(string email, string password)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByEmailAndPassword, "Admin");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Email", email);
                parametes.Add($"p_Password", password);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Admin>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
