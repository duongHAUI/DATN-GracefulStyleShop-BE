using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System.Data;
using System.Reflection;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class UserTokenDL : BaseDL<UserToken>, IUserTokenDL
    {
        public UserTokenDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public bool DeleleToken(string token)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.DeleteByToken, "UserToken");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Token", token);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Execute(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public UserToken GetUserByToken(string token)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByToken, "UserToken");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Token", token);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                UserToken result = _databaseConnection.QueryFirstOrDefault<UserToken>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

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

        public override bool Insert(UserToken entity)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.Insert, tableName);

                // Chuẩn bị parameters cho stored produce
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                {
                    var value = propertyInfo.GetValue(entity);
                    if (value != null && value.GetType().IsEnum)
                    {
                        parameters.Add("p_" + propertyInfo.Name, Convert.ToInt32(value));
                        continue;
                    }
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(entity));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý thêm dữ liệu trong stored
                int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                //Trả kết quả về
                return res == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
