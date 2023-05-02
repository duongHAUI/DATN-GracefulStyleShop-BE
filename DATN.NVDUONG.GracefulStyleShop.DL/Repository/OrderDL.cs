using Dapper;
using DATN.NVDUONG.GracefulStyleShop.Common.Constants;
using DATN.NVDUONG.GracefulStyleShop.Common;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.NVDUONG.GracefulStyleShop.DL.Repository
{
    public class OrderDL : BaseDL<Order>, IOrderDL
    {
        public OrderDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public bool Insert(Order order, List<OrderDetail> orderDetails, Guid customerId)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.Insert, tableName);

                // Chuẩn bị parameters cho stored produce
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in order.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType == typeof(List<OrderDetail>))
                        continue;
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(order));
                }

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);
                if(res > 0)
                {
                    res = _databaseConnection.InsertRecords<OrderDetail>(orderDetails);

                    if(res > 0)
                    {
                        string query = $"delete from Cart where CustomerId = '{customerId}'";
                        res = _databaseConnection.Execute(query, commandType: CommandType.Text);
                    }
                    if (res > 0) _databaseConnection.CommitTransaction();
                    else
                    {
                        _databaseConnection.RollbackTransaction();
                    }
                }
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
