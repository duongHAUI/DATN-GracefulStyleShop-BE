using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.NVDUONG.GracefulStyleShop.Common.Models.DTO;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class StatisticDL : IStatisticDL
    {
        #region Field
        protected IDatabaseConnection _databaseConnection;
        #endregion
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public StatisticDL(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public object StatisticsDefault()
        {
            try
            {
                var obj = new StatisticModel();
                // Tên store procedure
                string storedProcedureName = "Proc_Statistic_Default";

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add("p_FromDate", new DateTime());
                parameters.Add("p_ToDate", new DateTime());

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored

                var result = _databaseConnection.QueryMultiple(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);

                obj = result.ReadSingleOrDefault<StatisticModel>();

                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object SellingProductToMonthNow(SellingProductToMonthNow sellingProductToMonthNow)
        {
            try
            {
                var obj = new StatisticModel();
                // Tên store procedure
                string storedProcedureName = "Proc_Statistic_SellingProductToMonthNow";

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add("p_Year", sellingProductToMonthNow.Year);
                parameters.Add("p_Month", sellingProductToMonthNow.Month);

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored

                var result = _databaseConnection.Connection().Query<SellingProductToMonthNowResponse>(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);

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

        public List<StatisticRevenueResponse> StatisticRevenue(SellingProductToMonthNow sellingProductToMonthNow)
        {
            try
            {
                var obj = new StatisticModel();
                // Tên store procedure
                string storedProcedureName = "Proc_Statistic_StatisticRevenue";

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add("p_Year", sellingProductToMonthNow.Year);

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored

                var result = _databaseConnection.Connection().Query<StatisticRevenueResponse>(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
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
