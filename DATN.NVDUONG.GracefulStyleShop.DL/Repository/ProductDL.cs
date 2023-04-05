using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        private IDatabaseConnection _databaseConnection;
        public ProductDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
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
