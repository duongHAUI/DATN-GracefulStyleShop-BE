using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        private IDatabaseConnection _databaseConnection;
        public ProductDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>true - false</returns>
        public override bool DeleteRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.DeleteRecords, tableName);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Ids", string.Join(",", listGuid));

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.DeleteUpdateRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public bool UpdateSold(Guid productId, int sold)
        {
            try
            {
                string query = $"Update {tableName} set Sold = {sold} where {tableName}Id = {productId}";

                //Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu số lượng bán
                int numberUpdate = _databaseConnection.Execute(query, commandType: CommandType.Text);
                if (numberUpdate == 0)
                {
                    return false;
                }
                _databaseConnection.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
